using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class EraseUserConsumer : IConsumer<EraseUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EraseUserConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<EraseUser> context)
        {
            // should also delete file assets and remove asset urls

            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId)!;
            var email = user.Emails.First(x => x.IsPrimary).Email;
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();

            await context.Publish<UserErasedEvent>(new(context.Message.UserId, email));
        }
    }
}
