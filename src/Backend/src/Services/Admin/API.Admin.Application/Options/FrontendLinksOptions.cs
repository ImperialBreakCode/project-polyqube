using System.ComponentModel.DataAnnotations;

namespace API.Admin.Application.Options
{
    internal record FrontendLinksOptions
    {
        [Required]
        public string DeleteUserLink { get; init; }

        [Required]
        public string EmailVerificationLink { get; init; }
    }
}
