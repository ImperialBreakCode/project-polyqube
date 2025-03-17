using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Application.Features.Users.Options
{
    public record AuthTokenOptions
    {
        [Required]
        public string Issuer { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public string SecretKey { get; set; }
    }
}
