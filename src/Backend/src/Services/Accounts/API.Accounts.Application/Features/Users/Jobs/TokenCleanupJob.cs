using API.Accounts.Domain;
using Quartz;

namespace API.Accounts.Application.Features.Users.Jobs
{
    [DisallowConcurrentExecution]
    internal class TokenCleanupJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenCleanupJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _unitOfWork.EmailVerificationToken.RemoveExpiredTokens();
            await _unitOfWork.UserDeletionTokenRepository.RemoveExpiredTokens();
        }
    }
}
