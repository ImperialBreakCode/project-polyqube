namespace API.Accounts.Application.Features.Users.Models
{
    public record UserViewModel(
        string Id, 
        string Username, 
        string LockedOut, 
        bool Disabled, 
        bool Suspended,
        ICollection<UserEmailViewModel> UserEmails,
        UserDetailsViewModel? UserDetails,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
