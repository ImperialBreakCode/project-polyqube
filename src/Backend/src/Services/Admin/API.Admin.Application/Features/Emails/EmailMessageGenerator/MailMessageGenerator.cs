using API.Admin.Application.Features.Emails.EmailTemplates;
using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailMessageGenerator
{
    internal class MailMessageGenerator : IMailMessageGenerator
    {
        public MailMessage GetUserDeletionMailMessage(string deletionToken, string emailSender)
        {
            return new MailMessage()
            {
                From = new MailAddress(emailSender),
                Subject = "Account Deletion Request",
                Body = UserDeletionEmailTemplate.GetTemplate(deletionToken),
                IsBodyHtml = true
            };
        }
    }
}
