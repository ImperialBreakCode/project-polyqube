using API.Chats.Application.Features.Chats.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Chats.Queries.GetPeerChat
{
    public record GetPeerChatQuery(string CurrentProfileId, string PeerProfileId) : IQuery<ChatViewModel>;
}
