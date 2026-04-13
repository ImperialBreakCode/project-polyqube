using API.Chats.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain.Repositories
{
    public interface IParticipantRepository : ISoftDeleteRepository<Participant>
    {
        Task<ICollection<Participant>> GetChatParticipants(string chatId);
        Task<bool> PeerChatExistsForUsers(string firstUserId, string secondUserId);
    }
}
