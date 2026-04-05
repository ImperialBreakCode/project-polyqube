using API.Chats.Common.Features.ChatAgents.Exceptions;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.ChatAgents
{
    internal class ChatAgentRepository : InsertReadRepository<ChatAgent>, IChatAgentRepository
    {
        public ChatAgentRepository(DbSet<ChatAgent> dbSet) : base(dbSet)
        {
        }

        public async Task<ChatAgent?> GetByUsername(string username)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.AgentUsername == username);
        }

        public override void Insert(ChatAgent entity)
        {
            if (DbSet.Any(x => x.AgentUsername == entity.AgentUsername))
            {
                throw new AgentUsernameAlreadyExists();
            }

            base.Insert(entity);
        }
    }
}
