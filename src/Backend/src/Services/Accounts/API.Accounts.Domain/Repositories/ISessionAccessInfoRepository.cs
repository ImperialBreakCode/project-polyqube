using API.Shared.Domain.CacheEntities.Accounts;
using API.Shared.Domain.Interfaces.CacheRepo.Accounts;

namespace API.Accounts.Domain.Repositories
{
    public interface ISessionAccessInfoRepository : IReadSessionAccessInfoRepository
    {
        void SetSessionAccess(SessionAccessInfo userSession);
        void DeleteSessionAccess(string sessionId, string userId);
        void DeleteAllSessionAccessInfosByUser(string userId);
    }
}
