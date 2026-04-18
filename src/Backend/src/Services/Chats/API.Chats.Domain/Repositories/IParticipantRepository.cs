using API.Chats.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain.Repositories
{
    public interface IParticipantRepository : ISoftDeleteRepository<Participant>
    {
        Task<ICollection<Participant>> GetChatParticipants(
            string chatId, 
            bool includeDeleted = false, 
            int? participantCount = null,
            bool includeAgents = false);

        Task<Participant?> GetChatParticipantByProfileId(string profileId, string chatId, bool includeDeleted = false);
        Task<ICollection<Participant>> GetParticipantsWithChatByProfileId(string profileId, bool includeDeleted = false);
        Task<Participant?> GetChatParticipantByChatAgentId(string chatAgentId, string chatId, bool includeDeleted = false);
        Task<bool> PeerChatExistsForUsers(string firstUserId, string secondUserId);
    }
}
