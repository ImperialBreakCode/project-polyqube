using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Base.Results;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class CheckIfUserIdExistsConsumer : IConsumer<CheckIfUserIdExistsRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckIfUserIdExistsConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CheckIfUserIdExistsRequest> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId);
            if (user is null)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
            }
            else
            {
                await context.RespondAsync(BasicOperationResult.SuccessResult);
            }
        }
    }
}
