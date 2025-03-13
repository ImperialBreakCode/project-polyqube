using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record RefreshAuthTokensRequestDTO
    {
        [Required]
        public string RefreshToken { get; init; }
    }
}
