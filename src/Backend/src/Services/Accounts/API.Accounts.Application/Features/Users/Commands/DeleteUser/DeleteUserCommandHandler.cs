using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Events;
using API.Shared.Application.Interfaces;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IBus bus)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var token = await _unitOfWork.UserDeletionTokenRepository.GetTokenByTokenValueAsync(request.UserDeletionToken);

            if (token is null || DateTime.UtcNow >= token.Expiry)
            {
                throw new CannotDeleteUserException();
            }

            var userId = token.UserId;
            var email = token.User.Emails.First(x => x.IsPrimary).Email;
            await _bus.Publish<UserSoftDeletionInitiatedEvent>(new(userId, email), cancellationToken);

            _unitOfWork.UserDeletionTokenRepository.Delete(token);
            _unitOfWork.Save();
        }
    }
}
