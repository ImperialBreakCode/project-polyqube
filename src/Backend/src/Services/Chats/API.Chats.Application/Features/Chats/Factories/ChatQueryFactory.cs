using API.Chats.Application.Features.Chats.Queries.GetProfileChats;
using API.Chats.Application.Features.Chats.Queries.GetPeerChat;

namespace API.Chats.Application.Features.Chats.Factories
{
    internal class ChatQueryFactory : IChatQueryFactory
    {
        public GetProfileChatsQuery CreateGetProfileChatsQuery(string profileId)
        {
            return new GetProfileChatsQuery(profileId);
        }

        public GetPeerChatQuery CreateGetPeerChatQuery(string currentProfileId, string peerProfileId)
        {
            return new GetPeerChatQuery(currentProfileId, peerProfileId);
        }
    }
}
