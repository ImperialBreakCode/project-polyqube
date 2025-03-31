using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record RegisterUserRequestDTO
    {
        [Required]
        public string Username { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
