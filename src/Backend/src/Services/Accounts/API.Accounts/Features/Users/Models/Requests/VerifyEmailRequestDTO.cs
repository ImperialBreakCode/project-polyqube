using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record VerifyEmailRequestDTO
    {
        [Required]
        public string EmailVerificationToken { get; set; }
    }
}
