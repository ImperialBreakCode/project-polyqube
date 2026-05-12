using API.Chats.Domain.Aggregates;

namespace API.Chats.Application.Features.Messages.Models
{
    public record MessageViewModel(
        string Id,
        string TextContent,
        MessageType MessageType,
        string? ParticipantId,
        string ChatId,
        DateTime CreatedAt
    );
}
