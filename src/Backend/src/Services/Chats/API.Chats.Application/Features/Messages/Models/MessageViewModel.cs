using API.Chats.Domain.Aggregates;

namespace API.Chats.Application.Features.Messages.Models
{
    public record MessageViewModel(
        string TextContent,
        MessageType MessageType,
        string? ParticipantId,
        string ChatId
    );
}
