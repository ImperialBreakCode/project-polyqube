using API.Admin.Application.Features.Emails.EmailMessageGenerator;
using API.Admin.Application.Features.Emails.EmailSenders;
using API.Admin.Application.Features.Emails.Options;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;
using Microsoft.Extensions.Options;

namespace API.Admin.Application.Features.Emails.Consumers
{
    public class SendEmailOnSoftDeletedUserConsumer : IConsumer<UserSoftDeletedEvent>
    {
        private readonly IMailMessageGenerator _mailMessageGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IOptionsMonitor<EmailSenderOptions> _optionsMonitor;

        public SendEmailOnSoftDeletedUserConsumer(
            IMailMessageGenerator mailMessageGenerator, 
            IEmailSender emailSender, 
            IOptionsMonitor<EmailSenderOptions> optionsMonitor)
        {
            _mailMessageGenerator = mailMessageGenerator;
            _emailSender = emailSender;
            _optionsMonitor = optionsMonitor;
        }

        public async Task Consume(ConsumeContext<UserSoftDeletedEvent> context)
        {
            var message = _mailMessageGenerator.GetUserToBeDeletedMailMessage(_optionsMonitor.CurrentValue.SystemEmail);
            await _emailSender.SendEmailAsync([context.Message.Email], message, _optionsMonitor.CurrentValue);
        }
    }
}
