using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record ModuleLoginRequestDTO
    {
        [Required]
        public string Code { get; init; }
    }
}
