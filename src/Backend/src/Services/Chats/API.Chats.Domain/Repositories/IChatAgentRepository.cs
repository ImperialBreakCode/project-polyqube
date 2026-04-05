using API.Chats.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Chats.Domain.Repositories
{
    public interface IChatAgentRepository : IRepoInsert<ChatAgent>, IRepoRead<ChatAgent>
    {
        Task<ChatAgent?> GetByUsername(string username);
    }
}
