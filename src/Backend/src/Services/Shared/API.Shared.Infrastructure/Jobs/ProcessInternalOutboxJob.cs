using API.Shared.Domain.Entities;
using API.Shared.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;

namespace API.Shared.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    internal class ProcessInternalOutboxJob<TDbContext> : IJob
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<InternalOutboxEntity> _internalOutboxEntities;
        private readonly IPublisher _publisher;

        public ProcessInternalOutboxJob(TDbContext dbContext, IPublisher publisher)
        {
            _dbContext = dbContext;
            _internalOutboxEntities = _dbContext.Set<InternalOutboxEntity>();
            _publisher = publisher;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var outboxMessages = _internalOutboxEntities
                .Where(x => x.LockId == null)
                .Take(10)
                .AsNoTracking()
                .ToList();

            foreach (var message in outboxMessages)
            {
                var affected = await _internalOutboxEntities
                    .Where(x => x.Id == message.Id && x.LockId == null)
                    .ExecuteUpdateAsync(setters
                        => setters.SetProperty(x => x.LockId, x => Guid.NewGuid().ToString()));

                if (affected == 0)
                {
                    continue;
                }

                var success = await ProcessDomainEvent(JsonConvert.DeserializeObject<IDomainEvent>(message.Content)!);

                if (success)
                {
                    _internalOutboxEntities.Remove(message);
                }
            }

            _dbContext.SaveChanges();
        }

        private async Task<bool> ProcessDomainEvent(IDomainEvent message)
        {
            try
            {
                await _publisher.Publish(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
