using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class ReleaseUserSystemLockConsumer : IConsumer<ReleaseUserSystemLockRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReleaseUserSystemLockConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ReleaseUserSystemLockRequest> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId)!;
            user.SystemLock = false;
            _unitOfWork.Save();

            await context.RespondAsync(UserSystemLockReleasedResponse.Create(context.Message.UserId));
        }
    }
}
