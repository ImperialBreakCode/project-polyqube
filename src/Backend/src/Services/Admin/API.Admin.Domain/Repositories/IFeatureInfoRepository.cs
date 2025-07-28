using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Admin.Domain.Repositories
{
    public interface IFeatureInfoRepository : IRepoInsert<FeatureInfo>, IRepoRead<FeatureInfo>, IRepoUpdate<FeatureInfo>
    {
        Task<FeatureInfo?> GetByFeatureNameAsync(string featureName);
    }
}
