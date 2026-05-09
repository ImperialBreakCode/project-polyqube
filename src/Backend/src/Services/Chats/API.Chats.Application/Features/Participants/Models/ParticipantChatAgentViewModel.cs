namespace API.Chats.Application.Features.Participants.Models
{
    public record ParticipantChatAgentViewModel(
        string Id,
        string AgentName,
        string AgentUsername,
        string? ProfilePicture,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
