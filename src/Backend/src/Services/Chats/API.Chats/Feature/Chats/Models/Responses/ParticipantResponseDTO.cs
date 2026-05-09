namespace API.Chats.Feature.Chats.Models.Responses
{
    public record ParticipantResponseDTO(
        string Id,
        string? ChatNickname,
        ParticipantUserProfileResponseDTO? UserProfile,
        ParticipantChatAgentResponseDTO? ChatAgent
    );
}
