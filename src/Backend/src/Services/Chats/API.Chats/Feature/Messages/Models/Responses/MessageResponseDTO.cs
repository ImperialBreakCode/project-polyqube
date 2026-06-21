using API.Chats.Domain.Aggregates;

namespace API.Chats.Feature.Messages.Models.Responses
{
    public record MessageResponseDTO(
        string Id,
        string TextContent,
        MessageType MessageType,
        string? ParticipantId,
        string ChatId,
        DateTime CreatedAt
    );
}
