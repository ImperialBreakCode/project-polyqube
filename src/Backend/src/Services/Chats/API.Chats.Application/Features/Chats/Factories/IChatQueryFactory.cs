using API.Chats.Application.Features.Chats.Queries.GetProfileChats;
using API.Chats.Application.Features.Chats.Queries.GetPeerChat;

namespace API.Chats.Application.Features.Chats.Factories
{
    public interface IChatQueryFactory
    {
        GetProfileChatsQuery CreateGetProfileChatsQuery(string profileId);
        GetPeerChatQuery CreateGetPeerChatQuery(string currentProfileId, string peerProfileId);
    }
}
