using API.Admin.Domain.Repositories;

namespace API.Admin.Infrastructure.Factories
{
    internal interface IRepositoryFactory
    {
        IFeatureInfoRepository CreateFeatureInfoRepository(AdminDbContext dbContext);
    }
}
