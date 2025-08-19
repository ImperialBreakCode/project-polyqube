using System.ComponentModel.DataAnnotations;

namespace API.Admin.Application.Features.Emails.Options
{
    public record EmailSenderOptions
    {
        [Required]
        public string SystemEmail { get; init; }

        [Required]
        public string SmtpHost { get; init; }

        [Required]
        public int SmtpPort { get; init; }

        [Required]
        public string EmailUsername { get; init; }

        [Required]
        public string EmailPassword { get; init; }
    }
}
