using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Commands;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class ReleaseUserSystemLockConsumer : IConsumer<ReleaseUserSystemLock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReleaseUserSystemLockConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Consume(ConsumeContext<ReleaseUserSystemLock> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId)!;
            user.SystemLock = false;
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
