using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.ChatFeatures
{
    internal class ChatFeatureRepository : InsertReadRepository<ChatFeature>, IChatFeatureRepository
    {
        private readonly ChatDbContext _context;

        public ChatFeatureRepository(ChatDbContext context) : base(context.ChatFeatures)
        {
            _context = context;
        }

        public async Task<bool> CheckIfProfileIsFeatureRestricted(string profileId)
        {
            return await _context.FeatureRestrictedProfiles.AnyAsync(x => x.RestrictedProfileId == profileId);
        }

        public async Task<ChatFeature?> GetByFeatureName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.FeatureName == name);
        }
    }
}
