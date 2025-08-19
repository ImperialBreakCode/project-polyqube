using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers.SystemLockUserCD
{
    public class SystemLockUserConsumer : IConsumer<SystemLockUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemLockUserConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<SystemLockUser> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId);

            if (user is null || user.SystemLock)
            {
                throw new InvalidOperationException();
            }

            user.SystemLock = true;
            _unitOfWork.Save();

            await context.Publish<UserSystemLockedEvent>(new(context.Message.UserId));
        }
    }
}
