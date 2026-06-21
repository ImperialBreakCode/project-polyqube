namespace API.Chats.Application.Features.Participants.Models
{
    public record ParticipantUserProfileViewModel(
        string Id,
        string FullName,
        DateTime CreatedAt,
        DateTime UpdatedAt
    )
    {
        public string? ProfilePicture { get; set; }
    }
}
