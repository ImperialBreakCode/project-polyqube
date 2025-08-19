using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailMessageGenerator
{
    public interface IMailMessageGenerator
    {
        MailMessage GetUserDeletionRequestMailMessage(string deletionToken, string emailSender);
        MailMessage GetUserToBeDeletedMailMessage(string emailSender);
        MailMessage GetUserDeletionFailedToStartMailMessage(string emailSender);
    }
}
