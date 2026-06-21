using API.Chats.Domain;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.Chats.Requests;
using MassTransit;

namespace API.Chats.Application.Features.UserProfiles.Consumers
{
    public class CheckChatProfileExistsConsumer : IConsumer<CheckChatProfileExistsRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckChatProfileExistsConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CheckChatProfileExistsRequest> context)
        {
            var profile = _unitOfWork.UserProfileRepository.GetProfileByUserId(context.Message.UserId);
            if (profile == null)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
                return;
            }

            await context.RespondAsync(BasicOperationResult.SuccessResult);
        }
    }
}
