using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record ValidateAccessTokenRequestDTO
    {
        [Required]
        public string Token { get; init; }
    }
}
