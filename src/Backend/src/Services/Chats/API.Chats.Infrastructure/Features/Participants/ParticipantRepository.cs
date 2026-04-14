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

        public async Task<Participant?> GetChatParticipantByChatAgentId(string chatAgentId, string chatId)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.ChatAgentId == chatAgentId && x.ChatId == chatId);
        }

        public async Task<Participant?> GetChatParticipantByProfileId(string profileId, string chatId)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.UserProfileId == profileId && x.ChatId == chatId);
        }

        public async Task<ICollection<Participant>> GetChatParticipants(string chatId)
        {
            return await DbSet
                .Include(x => x.UserProfile)
                .Include(x => x.ChatAgent)
                .Where(x => x.ChatId == chatId)
                .ToListAsync();
        }

        public async Task<bool> PeerChatExistsForUsers(string firstProfileId, string secondProfileId)
        {
            return await DbSet
                .Where(x =>
                    !x.Chat.IsGroupChat
                    && (x.UserProfileId == firstProfileId || x.UserProfileId == secondProfileId))
                .GroupBy(x => x.ChatId)
                .AnyAsync(x => x.Count() > 1);
        }
    }
}
