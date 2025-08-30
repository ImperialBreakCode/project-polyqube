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
        private readonly IPublishEndpoint _publishEndpoint;

        public EraseUsersJob(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoind)
        {
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoind;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            ICollection<string> ids = await _unitOfWork.UserRepository.GetUserIdsForDeletion(TimeSpan.FromDays(7));

            foreach (string id in ids)
            {
                await _publishEndpoint.Publish<UserDeletionInitiatedEvent>(new(id));
            }
        }
    }
}
