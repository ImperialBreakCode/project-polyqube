using API.Admin.Application.Features.Emails.EmailMessageGenerator;
using API.Admin.Application.Features.Emails.EmailSenders;
using API.Admin.Application.Features.Emails.Options;
using API.Shared.Application.Contracts.Emails.Commands;
using MassTransit;
using Microsoft.Extensions.Options;

namespace API.Admin.Application.Features.Emails.Consumers
{
    public class SendEmailVerificationConsumer : IConsumer<SendEmailVerification>
    {
        private readonly IOptionsMonitor<EmailSenderOptions> _monitor;
        private readonly IEmailSender _emailSender;
        private readonly IMailMessageGenerator _mailMessageGenerator;

        public SendEmailVerificationConsumer(
            IOptionsMonitor<EmailSenderOptions> monitor, 
            IEmailSender emailSender, 
            IMailMessageGenerator mailMessageGenerator)
        {
            _monitor = monitor;
            _emailSender = emailSender;
            _mailMessageGenerator = mailMessageGenerator;
        }

        public async Task Consume(ConsumeContext<SendEmailVerification> context)
        {
            var message = _mailMessageGenerator
                .GetEmailVerificationEmailMailMessage(_monitor.CurrentValue.SystemEmail, context.Message.Token);

            await _emailSender.SendEmailAsync([context.Message.Email], message, _monitor.CurrentValue);
        }
    }
}
