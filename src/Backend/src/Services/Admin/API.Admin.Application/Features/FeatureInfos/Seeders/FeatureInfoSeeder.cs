using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Admin.Domain.Repositories;
using API.Shared.Common.Constants;

namespace API.Admin.Application.Features.FeatureInfos.Seeders
{
    internal class FeatureInfoSeeder : IFeatureInfoSeeder
    {
        public async Task SeedFeatureInfos(IFeatureInfoRepository featureInfoRepository)
        {
            await SeedFeatureInfo(featureInfoRepository, FeatureInfoNames.CHAT_SERVICE);
        }

        private async Task SeedFeatureInfo(IFeatureInfoRepository featureInfoRepository, string featureName, FeatureMode featureMode = FeatureMode.On)
        {
            FeatureInfo? featureInfo = await featureInfoRepository.GetByFeatureNameAsync(featureName);

            if (featureInfo is null)
            {
                featureInfo = FeatureInfo.Create(featureName, featureMode);
                featureInfoRepository.Insert(featureInfo);
            }
        }
    }
}
