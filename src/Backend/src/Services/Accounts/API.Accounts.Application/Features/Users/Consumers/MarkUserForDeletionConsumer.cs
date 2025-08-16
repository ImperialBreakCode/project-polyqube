using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Commands;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class MarkUserForDeletionConsumer : IConsumer<MarkUserForDeletion>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarkUserForDeletionConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Consume(ConsumeContext<MarkUserForDeletion> context)
        {
            var user = _unitOfWork.UserRepository.GetActiveEntityById(context.Message.UserId)!;
            user.SoftDelete();
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
