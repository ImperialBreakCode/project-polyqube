using API.Accounts.Domain;
using Quartz;

namespace API.Accounts.Application.Features.Users.Jobs
{
    [DisallowConcurrentExecution]
    internal class EraseUsersJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;

        public EraseUsersJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            ICollection<string> ids = await _unitOfWork.UserRepository.GetUserIdsForDeletion(TimeSpan.FromSeconds(15));

            foreach (string id in ids)
            {
                // initiate machine to erase users
                Console.WriteLine(id);
            }
        }
    }
}
