using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain.Repositories
{
    public interface IUserProfileRepository : ISoftDeleteRepository<UserProfile>
    {
        Task<UserProfile?> GetProfileByUserId(string userId, bool includeDeleted = default);
        Task<ICollection<BlockedProfile>> GetBlockedProfilesByBlockedProfileId(string profileId);
    }
}
