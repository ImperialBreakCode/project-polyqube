using API.Admin.Application.Features.Emails.Options;
using System.Net;
using System.Net.Mail;

namespace API.Admin.Application.Features.Emails.EmailSenders
{
    internal class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string[] recipients, MailMessage mailMessage, EmailSenderOptions emailSenderOptions)
        {
            foreach (var email in recipients)
            {
                mailMessage.To.Add(email);
            }

            using (var client = new SmtpClient(emailSenderOptions.SmtpHost, emailSenderOptions.SmtpPort))
            {
                client.Credentials = new NetworkCredential(emailSenderOptions.EmailUsername, emailSenderOptions.EmailPassword);
                client.EnableSsl = true;

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
