using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailMessageGenerator
{
    public interface IMailMessageGenerator
    {
        MailMessage GetUserDeletionMailMessage(string deletionToken, string emailSender);
        MailMessage GetUserToBeDeletedMailMessage(string emailSender);
    }
}
