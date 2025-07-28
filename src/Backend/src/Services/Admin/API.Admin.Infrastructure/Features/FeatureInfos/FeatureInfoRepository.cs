using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Admin.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Admin.Infrastructure.Features.FeatureInfos
{
    internal class FeatureInfoRepository : CRURepository<FeatureInfo>, IFeatureInfoRepository
    {
        public FeatureInfoRepository(DbSet<FeatureInfo> dbSet) : base(dbSet)
        {
        }

        public async Task<FeatureInfo?> GetByFeatureNameAsync(string featureName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.FeatureName == featureName);
        }
    }
}
