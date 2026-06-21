using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record ModuleLogoutRequestDTO
    {
        [Required]
        public string ServiceName { get; init; }
    }
}
