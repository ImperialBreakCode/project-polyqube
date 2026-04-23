using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record ModuleAccessRequestDTO
    {
        [Required]
        public string AccessToken { get; init; }

        [Required]
        public string RefreshToken { get; init; }

        [Required]
        public string ModuleName { get; init; }
    }
}
