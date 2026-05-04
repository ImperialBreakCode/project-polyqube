using API.Shared.Common.MediatorResponse;

namespace API.Chats.Application.Features.UserProfiles.Models
{
    public record UserProfileViewModel(
        string Id, 
        string UserId, 
        string FirstName, 
        string LastName,
        bool LockedOut,
        bool Disabled,
        bool Suspended,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        DateTime DeletedAt) : IInterceptableResponse
    {
        public string? ProfilePicture { get; set; }
    };
}
