namespace API.Chats.Feature.Chats.Models.Responses
{
    public record TypingStateResponseDTO(
        string ChatId,
        string ParticipantId,
        bool IsTyping,
        string DisplayName,
        bool IsBot,
        string? ProfilePicture);
}
