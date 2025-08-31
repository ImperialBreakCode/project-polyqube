using API.Shared.Domain.Entities;
using API.Shared.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace API.Shared.Infrastructure.Interceptors
{
    internal class InternalOutboxInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is not null)
            {
                var changeTracker = eventData.Context.ChangeTracker;

                var outboxMessages = changeTracker
                    .Entries<IAggregateRoot>()
                    .Select(x => x.Entity)
                    .SelectMany(x =>
                    {
                        var events = x.DomainEvents;
                        x.ClearDomainEvents();

                        return events;
                    })
                    .Select(domainEvent 
                        => InternalOutboxEntity.Create(
                            JsonConvert.SerializeObject(
                                domainEvent, 
                                new JsonSerializerSettings()
                                {
                                    TypeNameHandling = TypeNameHandling.All,
                                }),
                            domainEvent.GetType().Name))
                    .ToList();

                if (outboxMessages.Count > 0)
                {
                    eventData.Context.Set<InternalOutboxEntity>().AddRange(outboxMessages);
                }
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
