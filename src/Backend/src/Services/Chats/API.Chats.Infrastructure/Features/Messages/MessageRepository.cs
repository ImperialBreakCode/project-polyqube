using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.Messages
{
    internal class MessageRepository : SoftDeleteRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbSet<Message> dbSet) : base(dbSet)
        {
        }

        public async Task<ICollection<Message>> GetMessageChatHistory(string chatId, int count, int offset = 0)
        {
            return await DbSet
                .Where(x => x.ChatId == chatId)
                .OrderBy(x => x.CreatedAt)
                .Take(count)
                .Skip(offset)
                .ToListAsync();
        }
    }
}
