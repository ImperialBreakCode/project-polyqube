using API.Admin.Domain.Repositories;
using API.Admin.Infrastructure.Features.FeatureInfos;

namespace API.Admin.Infrastructure.Factories
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IFeatureInfoRepository CreateFeatureInfoRepository(AdminDbContext dbContext)
        {
            return new FeatureInfoRepository(dbContext.FeatureInfos);
        }
    }
}
