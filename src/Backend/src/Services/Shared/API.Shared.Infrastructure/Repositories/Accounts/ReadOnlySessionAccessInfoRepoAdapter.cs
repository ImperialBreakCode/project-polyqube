using API.Shared.Domain.CacheEntities.Accounts;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Domain.Interfaces.CacheRepo.Accounts;
using API.Shared.Infrastructure.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace API.Shared.Infrastructure.Repositories.Accounts
{
    public class ReadOnlySessionAccessInfoRepoAdapter : IReadSessionAccessInfoRepository
    {
        private readonly ICacheRepository<SessionAccessInfo> _repo;
        private readonly IServer _server;

        public ReadOnlySessionAccessInfoRepoAdapter(
            ICacheRepository<SessionAccessInfo> sessionRepo,
            IOptionsMonitor<RedisOptions> redisOptions,
            IConnectionMultiplexer multiplexer)
        {
            _repo = sessionRepo;
            _server = multiplexer.GetServer(redisOptions.CurrentValue.RedisHost);
        }

        protected ICacheRepository<SessionAccessInfo> CacheRepo => _repo;

        public ICollection<SessionAccessInfo> GetAllSessionInfosByUser(string userId)
        {
            var keys = GetSessionAccessInfoKeysByUser(userId);

            ICollection<SessionAccessInfo> sessionInfos = [];
            foreach (var key in keys)
            {
                var keyArr = key.ToString().Split('_');
                var sessionInfo = GetSessionInfo(keyArr[^1], keyArr[^2]);
                if (sessionInfo is not null)
                {
                    sessionInfos.Add(sessionInfo);
                }
            }

            return sessionInfos;
        }

        public SessionAccessInfo? GetSessionInfo(string sessionId, string userId)
        {
            return _repo.Get($"{userId}_{sessionId}");
        }

        protected IEnumerable<RedisKey> GetSessionAccessInfoKeysByUser(string userId)
        {
            return _server.Keys(pattern: $"*_{userId}_*");
        }
    }
}
