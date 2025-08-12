using API.Admin.Application.Features.Emails.EmailMessageGenerator;
using API.Admin.Application.Features.Emails.EmailSenders;
using API.Admin.Application.Features.Emails.Options;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.Emails.Requests;
using MassTransit;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.Consumers
{
    public class SendUserDeletionEmailConsumer : IConsumer<SendUserDeletionEmailRequest>
    {
        private readonly IMailMessageGenerator _mailMessageGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IOptionsMonitor<EmailSenderOptions> _emailOptions;

        public SendUserDeletionEmailConsumer(
            IMailMessageGenerator mailMessageGenerator, 
            IEmailSender emailSender, 
            IOptionsMonitor<EmailSenderOptions> emailOptions)
        {
            _mailMessageGenerator = mailMessageGenerator;
            _emailSender = emailSender;
            _emailOptions = emailOptions;
        }

        public async Task Consume(ConsumeContext<SendUserDeletionEmailRequest> context)
        {
            var message = _mailMessageGenerator
                .GetUserDeletionMailMessage(context.Message.DeletionToken, _emailOptions.CurrentValue.SystemEmail);

            try
            {
                await _emailSender.SendEmailAsync([context.Message.Email], message, _emailOptions.CurrentValue);
                await context.RespondAsync(BasicOperationResult.SuccessResult);
            }
            catch (SmtpException)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
            }
        }
    }
}
