using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Application.Features.Users.Options
{
    internal record InitialSuperAdminOptions
    {
        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
