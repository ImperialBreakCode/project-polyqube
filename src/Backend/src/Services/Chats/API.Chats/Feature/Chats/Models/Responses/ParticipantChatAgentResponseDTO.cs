namespace API.Chats.Feature.Chats.Models.Responses
{
    public record ParticipantChatAgentResponseDTO(
        string Id,
        string AgentName,
        string AgentUsername,
        string? ProfilePicture,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
