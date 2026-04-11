namespace API.Chats.Feature.UserProfiles.Models.Responses
{
    public record UserProfileResponseDTO(
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
