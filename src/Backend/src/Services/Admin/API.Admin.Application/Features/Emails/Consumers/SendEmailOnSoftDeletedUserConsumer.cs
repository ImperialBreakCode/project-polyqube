using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;

namespace API.Admin.Application.Features.Emails.Consumers
{
    public class SendEmailOnSoftDeletedUserConsumer : IConsumer<UserSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<UserSoftDeletedEvent> context)
        {
            // send email

            return Task.CompletedTask;
        }
    }
}
