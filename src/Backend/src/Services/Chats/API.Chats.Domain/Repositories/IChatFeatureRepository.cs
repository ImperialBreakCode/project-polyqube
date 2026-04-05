using API.Chats.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Chats.Domain.Repositories
{
    public interface IChatFeatureRepository: IRepoInsert<ChatFeature>, IRepoRead<ChatFeature>
    {
        Task<ChatFeature?> GetByFeatureName(string name);

        Task<bool> CheckIfProfileIsFeatureRestricted(string profileId);
    }
}
