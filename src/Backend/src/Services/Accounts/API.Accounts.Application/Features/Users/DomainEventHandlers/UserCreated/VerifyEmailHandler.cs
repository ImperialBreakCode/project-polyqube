using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate.DomainEvents;
using API.Shared.Application.Contracts.Accounts.Commands;
using MassTransit;
using MediatR;

namespace API.Accounts.Application.Features.Users.DomainEventHandlers.UserCreated
{
    public class VerifyEmailHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly IUnitOfWork _unitOfWork;

        public VerifyEmailHandler(IPublishEndpoint endpoint, IUnitOfWork unitOfWork)
        {
            _endpoint = endpoint;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: create and save token

            var user = _unitOfWork.UserRepository.GetActiveEntityById(notification.UserId);

            if (user is null)
            {
                return;
            }

            var email = user.Emails.First(x => x.IsPrimary).Email;
            var testToken = "sometoken";

            await _endpoint.Publish(new SendEmailVerification(email, testToken));
        }
    }
}
