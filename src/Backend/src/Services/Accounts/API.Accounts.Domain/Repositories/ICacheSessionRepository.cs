using API.Accounts.Domain.CacheEntities;

namespace API.Accounts.Domain.Repositories
{
    public interface ICacheSessionRepository
    {
        ICollection<UserSession> GetAllSessionsByUser(string userId);
        UserSession? GetSession(string sessionId, string userId);
        void SetSession(UserSession userSession);
        void DeleteSession(string sessionId, string userId);
        void DeleteAllSessionsByUser(string userId);
    }
}
