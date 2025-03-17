namespace API.Accounts.Application.Features.Users.Models
{
    public record UserViewModel(
        string Id, 
        string Username, 
        bool LockedOut, 
        bool Disabled, 
        bool Suspended,
        ICollection<UserEmailViewModel> Emails,
        UserDetailsViewModel? UserDetails,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
