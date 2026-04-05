using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.ChatFeatures
{
    internal class ChatFeatureRepository : InsertReadRepository<ChatFeature>, IChatFeatureRepository
    {
        public ChatFeatureRepository(DbSet<ChatFeature> dbSet) : base(dbSet)
        {
        }

        public async Task<ChatFeature?> GetByFeatureName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.FeatureName == name);
        }
    }
}
