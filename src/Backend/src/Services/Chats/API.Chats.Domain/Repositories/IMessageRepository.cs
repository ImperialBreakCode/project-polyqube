using API.Chats.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain.Repositories
{
    public interface IMessageRepository : ISoftDeleteRepository<Message>
    {
        Task<ICollection<Message>> GetMessageChatHistory(string chatId, int count, int offset = 0);
    }
}
