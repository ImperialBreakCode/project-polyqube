using API.Shared.Domain.CacheEntities.Accounts;

namespace API.Shared.Domain.Interfaces.CacheRepo.Accounts
{
    public interface IReadSessionAccessInfoRepository
    {
        ICollection<SessionAccessInfo> GetAllSessionInfosByUser(string userId);
        SessionAccessInfo? GetSessionInfo(string sessionId, string userId);
    }
}
