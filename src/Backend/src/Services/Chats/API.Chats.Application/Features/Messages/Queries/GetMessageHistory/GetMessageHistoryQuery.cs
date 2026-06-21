using API.Chats.Application.Features.Messages.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Messages.Queries.GetMessageHistory
{
    public record GetMessageHistoryQuery(
        string ChatId,
        int Count,
        int Offset) : IQuery<ICollection<MessageViewModel>>;
}
