using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Application.Features.Users.Options
{
    internal record InitialSuperAdminOptions
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
