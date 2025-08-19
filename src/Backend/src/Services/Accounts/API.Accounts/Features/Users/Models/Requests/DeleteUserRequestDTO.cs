using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record DeleteUserRequestDTO
    {
        [Required]
        public string UserDeletionToken { get; set; }
    }
}
