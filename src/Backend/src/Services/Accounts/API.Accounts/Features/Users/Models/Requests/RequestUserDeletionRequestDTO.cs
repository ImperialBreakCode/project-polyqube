using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record RequestUserDeletionRequestDTO
    {
        [Required]
        public string Password { get; init; }
    }
}
