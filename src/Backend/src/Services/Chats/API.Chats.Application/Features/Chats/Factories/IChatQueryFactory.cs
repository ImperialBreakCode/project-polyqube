using API.Chats.Application.Features.Chats.Queries.GetProfileChats;
using API.Chats.Application.Features.Chats.Queries.GetPeerChat;
using API.Chats.Application.Features.Participants.Queries.GetChatParticipants;

namespace API.Chats.Application.Features.Chats.Factories
{
    public interface IChatQueryFactory
    {
        GetProfileChatsQuery CreateGetProfileChatsQuery(string profileId);
        GetPeerChatQuery CreateGetPeerChatQuery(string currentProfileId, string peerProfileId);
        GetChatParticipantsQuery CreateGetChatParticipantsQuery(string chatId, int? participantCount = null, bool includeAgents = false);
    }
}
