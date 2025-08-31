using API.Admin.Application.Features.FeatureInfos.Models;
using API.Shared.Application.Interfaces;

namespace API.Admin.Application.Features.FeatureInfos.Queries.GetFeatureInfoByName
{
    public record GetFeatureInfoByNameQuery(string FeatureName) : IQuery<FeatureInfoViewModel>;
}
