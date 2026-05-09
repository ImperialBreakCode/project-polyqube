namespace API.Chats.Application.Features.Participants.Models
{
    public record ParticipantViewModel(
        string Id,
        string? ChatNickname,
        ParticipantUserProfileViewModel? UserProfile,
        ParticipantChatAgentViewModel? ChatAgent,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
