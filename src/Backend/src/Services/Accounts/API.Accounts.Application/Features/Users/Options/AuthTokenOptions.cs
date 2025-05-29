using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Application.Features.Users.Options
{
    public record AuthTokenOptions
    {
        [Required]
        public string Issuer { get; init; }

        [Required]
        public string Audience { get; init; }

        [Required]
        public string SecretKey { get; init; }
    }
}
