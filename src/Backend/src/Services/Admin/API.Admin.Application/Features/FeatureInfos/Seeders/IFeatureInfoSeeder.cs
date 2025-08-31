using API.Admin.Domain.Repositories;

namespace API.Admin.Application.Features.FeatureInfos.Seeders
{
    internal interface IFeatureInfoSeeder
    {
        Task SeedFeatureInfos(IFeatureInfoRepository featureInfoRepository);
    }
}
