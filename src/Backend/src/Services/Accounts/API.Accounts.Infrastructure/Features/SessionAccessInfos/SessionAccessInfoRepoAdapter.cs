using API.Accounts.Domain.Repositories;
using API.Shared.Domain.CacheEntities.Accounts;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Infrastructure.Options;
using API.Shared.Infrastructure.Repositories.Accounts;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace API.Accounts.Infrastructure.Features.SessionAccessInfos
{
    internal class SessionAccessInfoRepoAdapter : ReadOnlySessionAccessInfoRepoAdapter, ISessionAccessInfoRepository
    {
        public SessionAccessInfoRepoAdapter(
            ICacheRepository<SessionAccessInfo> sessionRepo, 
            IOptionsMonitor<RedisOptions> redisOptions, 
            IConnectionMultiplexer multiplexer) 
            : base(sessionRepo, redisOptions, multiplexer)
        {
        }

        public void DeleteAllSessionAccessInfosByUser(string userId)
        {
            var keys = GetSessionAccessInfoKeysByUser(userId);
            foreach (var key in keys)
            {
                var keyArr = key.ToString().Split('_');
                DeleteSessionAccess(keyArr[^1], keyArr[^2]);
            }
        }

        public void DeleteSessionAccess(string sessionId, string userId)
        {
            CacheRepo.Delete($"{userId}_{sessionId}");
        }

        public void SetSessionAccess(SessionAccessInfo userSession)
        {
            CacheRepo.Set($"{userSession.UserId}_{userSession.SessionId}", userSession, userSession.Expiration);
        }
    }
}
