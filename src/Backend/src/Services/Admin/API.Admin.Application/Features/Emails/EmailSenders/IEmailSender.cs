using API.Admin.Application.Features.Emails.Options;
using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailSenders
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string[] recipients, MailMessage mailMessage, EmailSenderOptions emailSenderOptions);
    }
}
