using API.Chats.Application.Features.Chats.Queries.GetProfileChats;
using API.Chats.Application.Features.Chats.Queries.GetPeerChat;
using API.Chats.Application.Features.Participants.Queries.GetChatParticipants;

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

        public GetChatParticipantsQuery CreateGetChatParticipantsQuery(string chatId, int? participantCount = null, bool includeAgents = false)
        {
            return new GetChatParticipantsQuery(chatId, participantCount, includeAgents);
        }
    }
}
