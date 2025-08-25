using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;
using Quartz;

namespace API.Accounts.Application.Features.Users.Jobs
{
    [DisallowConcurrentExecution]
    internal class EraseUsersJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;

        public EraseUsersJob(IUnitOfWork unitOfWork, IBus bus)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            ICollection<string> ids = await _unitOfWork.UserRepository.GetUserIdsForDeletion(TimeSpan.FromSeconds(15));

            foreach (string id in ids)
            {
                await _bus.Publish<UserDeletionInitiatedEvent>(new(id));
            }
        }
    }
}
