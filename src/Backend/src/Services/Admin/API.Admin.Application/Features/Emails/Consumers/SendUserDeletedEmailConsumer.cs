using API.Admin.Application.Features.Emails.EmailMessageGenerator;
using API.Admin.Application.Features.Emails.EmailSenders;
using API.Admin.Application.Features.Emails.Options;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;
using Microsoft.Extensions.Options;

namespace API.Admin.Application.Features.Emails.Consumers
{
    public class SendUserDeletedEmailConsumer : IConsumer<UserDeletionCompletedEvent>
    {
        private readonly IOptionsMonitor<EmailSenderOptions> _optionsMonitor;
        private readonly IEmailSender _emailSender;
        private readonly IMailMessageGenerator _mailMessageGenerator;

        public SendUserDeletedEmailConsumer(
            IOptionsMonitor<EmailSenderOptions> optionsMonitor, 
            IEmailSender emailSender, 
            IMailMessageGenerator mailMessageGenerator)
        {
            _optionsMonitor = optionsMonitor;
            _emailSender = emailSender;
            _mailMessageGenerator = mailMessageGenerator;
        }

        public async Task Consume(ConsumeContext<UserDeletionCompletedEvent> context)
        {
            var message = _mailMessageGenerator.GetUserDeletedMailMessage(_optionsMonitor.CurrentValue.SystemEmail);

            await _emailSender.SendEmailAsync([context.Message.Email], message, _optionsMonitor.CurrentValue);
        }
    }
}
