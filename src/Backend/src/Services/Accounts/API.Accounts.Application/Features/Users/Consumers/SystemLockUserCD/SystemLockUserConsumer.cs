using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers.SystemLockUserCD
{
    public class SystemLockUserConsumer : IConsumer<SystemLockUserRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemLockUserConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<SystemLockUserRequest> context)
        {
            var lockSuccessful = await _unitOfWork.UserRepository.ConcurrencySystemLock(context.Message.UserId);
            if (!lockSuccessful)
            {
                throw new InvalidOperationException();
            }

            await context.RespondAsync(UserSystemLockedResponse.Create(context.Message.UserId));
        }
    }
}
