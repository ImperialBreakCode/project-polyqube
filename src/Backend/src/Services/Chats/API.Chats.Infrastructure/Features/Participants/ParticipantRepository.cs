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

        public async Task<Participant?> GetChatParticipantByChatAgentId(string chatAgentId, string chatId, bool includeDeleted = false)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => 
                    x.ChatAgentId == chatAgentId 
                    && x.ChatId == chatId 
                    && (includeDeleted || x.DeletedAt == null));
        }

        public async Task<Participant?> GetChatParticipantByProfileId(string profileId, string chatId, bool includeDeleted = false)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => 
                    x.UserProfileId == profileId 
                    && x.ChatId == chatId
                    && (includeDeleted || x.DeletedAt == null));
        }

        public async Task<ICollection<Participant>> GetChatParticipants(
            string chatId,
            bool includeDeleted = false,
            int? participantCount = null,
            bool includeAgents = false)
        {
            var query = DbSet
                .Include(x => x.UserProfile)
                .Include(x => x.ChatAgent)
                .Where(x => 
                    x.ChatId == chatId 
                    && (includeDeleted || x.DeletedAt == null)
                    && (includeAgents || x.ChatAgentId == null));

            if (participantCount.HasValue)
            {
                query = query.Take(participantCount.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<ICollection<Participant>> GetParticipantsWithChatByProfileId(string profileId, bool includeDeleted = false)
        {
            return await DbSet
                .Include(x => x.Chat)
                .Where(x => x.UserProfileId == profileId && (includeDeleted || x.DeletedAt == null))
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
