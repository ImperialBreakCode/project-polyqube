namespace API.Chats.Application.Features.UserProfiles.Models
{
    public record UserProfileViewModel(
        string Id, 
        string UserId, 
        string FirstName, 
        string LastName,
        string ProfilePicture,
        bool LockedOut,
        bool Disabled,
        bool Suspended,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        DateTime DeletedAt);
}
