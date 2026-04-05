using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.Participants
{
    internal class ParticipantRepository : SoftDeleteRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(DbSet<Participant> dbSet) : base(dbSet)
        {
        }

        public async Task<ICollection<Participant>> GetChatParticipants(string chatId)
        {
            return await DbSet
                .Include(x => x.UserProfile)
                .Include(x => x.ChatAgent)
                .Where(x => x.ChatId == chatId)
                .ToListAsync();
        }
    }
}
