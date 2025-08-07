using API.Admin.Application.Features.FeatureInfos.Queries.GetFeatureInfoByName;

namespace API.Admin.Application.Features.FeatureInfos.Factories
{
    internal class FeatureInfoQueryFactory : IFeatureInfoQueryFactory
    {
        public GetFeatureInfoByNameQuery CreateGetFeatureInfoByNameQuery(string featureName)
        {
            return new GetFeatureInfoByNameQuery(featureName);
        }
    }
}
