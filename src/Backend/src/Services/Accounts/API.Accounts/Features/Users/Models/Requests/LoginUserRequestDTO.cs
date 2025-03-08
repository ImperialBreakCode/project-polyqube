using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record LoginUserRequestDTO
    {
        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
