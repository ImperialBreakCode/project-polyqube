using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate.DomainEvents;
using API.Shared.Application.Contracts.Emails.Commands;
using MassTransit;
using MediatR;

namespace API.Accounts.Application.Features.Users.DomainEventHandlers.EmailAdded
{
    public class VerifyEmailHandler : INotificationHandler<EmailAddedDomainEvent>
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly IUnitOfWork _unitOfWork;

        public VerifyEmailHandler(IPublishEndpoint endpoint, IUnitOfWork unitOfWork)
        {
            _endpoint = endpoint;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EmailAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetActiveEntityById(notification.UserId);
            if (user is null)
            {
                return;
            }

            var emailEntity = user.Emails.FirstOrDefault(x => x.Email == notification.Email);
            if (emailEntity is null)
            {
                return;
            }

            var token = EmailVerificationToken.Create(user, emailEntity.Email);

            _unitOfWork.EmailVerificationToken.Insert(token);
            _unitOfWork.Save();

            await _endpoint.Publish(new SendEmailVerification(emailEntity.Email, token.Token), cancellationToken);
        }
    }
}
