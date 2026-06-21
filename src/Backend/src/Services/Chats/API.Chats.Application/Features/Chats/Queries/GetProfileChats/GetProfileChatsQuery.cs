using API.Chats.Application.Features.Chats.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Chats.Queries.GetProfileChats
{
    public record GetProfileChatsQuery(string ProfileId, bool PreloadChatName = true) : IQuery<ICollection<ChatViewModel>>;
}
