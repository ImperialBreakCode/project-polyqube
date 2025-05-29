using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record SetProfilePictureRequestDTO
    {
        [Required]
        public IFormFile FormFile { get; init; }
    }
}
