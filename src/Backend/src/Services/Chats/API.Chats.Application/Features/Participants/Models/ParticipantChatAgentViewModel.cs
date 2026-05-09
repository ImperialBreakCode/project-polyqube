namespace API.Chats.Application.Features.Participants.Models
{
    public record ParticipantChatAgentViewModel(
        string Id,
        string AgentName,
        string AgentUsername,
        DateTime CreatedAt,
        DateTime UpdatedAt
    )
    {
        public string? ProfilePicture { get; set; }
    }
}
