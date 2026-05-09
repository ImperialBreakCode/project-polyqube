namespace API.Chats.Application.Features.Participants.Models
{
    public record ParticipantUserProfileViewModel(
        string Id,
        string FullName,
        string? ProfilePicture
    );
}
