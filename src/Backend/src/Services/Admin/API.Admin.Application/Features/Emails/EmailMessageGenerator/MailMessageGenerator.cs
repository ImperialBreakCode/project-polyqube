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

        public MailMessage GetUserDeletionMailMessage(string deletionToken, string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account Deletion Request",
                Body = UserDeletionEmailTemplate.GetTemplate(_optionsMonitor.CurrentValue.DeleteUserLink + deletionToken),
                IsBodyHtml = true
            };
        }

        public MailMessage GetUserToBeDeletedMailMessage(string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account Deletion",
                Body = UserDeletionEmailTemplate.GetTemplate(emailSender),
                IsBodyHtml = true
            };
        }
    }
}
