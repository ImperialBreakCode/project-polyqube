using API.Admin.Application.Features.FeatureInfos.Queries.GetFeatureInfoByName;

namespace API.Admin.Application.Features.FeatureInfos.Factories
{
    public interface IFeatureInfoQueryFactory
    {
        GetFeatureInfoByNameQuery CreateGetFeatureInfoByNameQuery(string featureName);
    }
}
