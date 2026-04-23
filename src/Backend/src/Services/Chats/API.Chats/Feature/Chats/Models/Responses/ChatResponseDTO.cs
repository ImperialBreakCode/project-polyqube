namespace API.Chats.Feature.Chats.Models.Responses
{
    public record ChatResponseDTO(
        string Id,
        string? ChatName,
        bool IsGroupChat,
        bool AIEnabled
    );
}
