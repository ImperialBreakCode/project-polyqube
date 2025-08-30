using API.Admin.Application.Features.Emails.EmailTemplates;
using API.Admin.Application.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailMessageGenerator
{
    internal class MailMessageGenerator : IMailMessageGenerator
    {
        private readonly IOptionsMonitor<FrontendLinksOptions> _optionsMonitor;

        public MailMessageGenerator(IOptionsMonitor<FrontendLinksOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        public MailMessage GetEmailVerificationEmailMailMessage(string emailSender, string verificationToken)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Verify your email",
                Body = VerifyEmailEmailTemplate.GetTemplate(_optionsMonitor.CurrentValue.EmailVerificationLink + verificationToken)
            };
        }

        public MailMessage GetUserDeletedMailMessage(string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account deleted",
                Body = UserDeletedEmailTemplate.Template,
                IsBodyHtml = true,
            };
        }

        public MailMessage GetUserDeletionFailedToStartMailMessage(string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account deletion failed to start",
                Body = UserDeletionInitFailedEmailTemplate.Template,
                IsBodyHtml = true,
            };
        }

        public MailMessage GetUserDeletionRequestMailMessage(string deletionToken, string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account Deletion Request",
                Body = UserDeletionRequestEmailTemplate.GetTemplate(_optionsMonitor.CurrentValue.DeleteUserLink + deletionToken),
                IsBodyHtml = true
            };
        }

        public MailMessage GetUserToBeDeletedMailMessage(string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account Deletion Started",
                Body = UserToBeDeletedEmailTemplate.Template,
                IsBodyHtml = true
            };
        }
    }
}
