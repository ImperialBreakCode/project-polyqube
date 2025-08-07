using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Admin.Domain.Repositories
{
    public interface IFeatureInfoRepository : IRepoInsert<FeatureInfo>, IRepoRead<FeatureInfo>, IRepoUpdate<FeatureInfo>
    {
        Task<FeatureInfo?> GetByFeatureNameAsync(string featureName);
        Task<ICollection<RestrictedUser>> GetRestrictedUsersAsync(string featureId, int startPosition, int count = 100);
        Task<ICollection<TestUser>> GetTestUsersAsync(string featureId, int startPosition, int count = 100);
        Task<bool> CheckIfUserIsRestrictedAsync(string featureId, string userId);
        Task<bool> CheckIfUserIsTestUserAsync(string featureId, string userId);
        Task AddRestrictedUserAsync(RestrictedUser restrictedUser);
        void RemoveRestrictedUser(RestrictedUser restrictedUser);
        Task AddTestUserAsync(TestUser testUser);
        void RemoveTestUser(TestUser testUser);
    }
}
