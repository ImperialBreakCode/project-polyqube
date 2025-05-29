using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Infrastructure.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace API.Accounts.Infrastructure.Features.Sessions
{
    internal class SessionRepositoryAdapter : ICacheSessionRepository
    {
        private readonly ICacheRepository<UserSession> _sessionRepo;
        private readonly IServer _server;

        public SessionRepositoryAdapter(
            ICacheRepository<UserSession> sessionRepo, 
            IOptionsMonitor<RedisOptions> redisOptions,
            IConnectionMultiplexer multiplexer)
        {
            _sessionRepo = sessionRepo;
            _server = multiplexer.GetServer(redisOptions.CurrentValue.RedisHost);
        }

        public void DeleteAllSessionsByUser(string userId)
        {
            var keys = GetSessionKeysByUser(userId);
            foreach (var key in keys)
            {
                var keyArr = key.ToString().Split('_');
                DeleteSession(keyArr[^1], keyArr[^2]);
            }
        }

        public void DeleteSession(string sessionId, string userId)
        {
            _sessionRepo.Delete($"{userId}_{sessionId}");
        }

        public ICollection<UserSession> GetAllSessionsByUser(string userId)
        {
            var keys = GetSessionKeysByUser(userId);

            ICollection<UserSession> sessions = [];
            foreach (var key in keys)
            {
                var keyArr = key.ToString().Split('_');
                var session = GetSession(keyArr[^1], keyArr[^2]);
                if (session is not null)
                {
                    sessions.Add(session);
                }
            }

            return sessions;
        }

        public UserSession? GetSession(string sessionId, string userId)
        {
            return _sessionRepo.Get($"{userId}_{sessionId}");
        }

        public void SetSession(UserSession userSession)
        {
            _sessionRepo.Set($"{userSession.UserId}_{userSession.SessionId}", userSession, userSession.Expiration);
        }

        private IEnumerable<RedisKey> GetSessionKeysByUser(string userId)
        {
            return _server.Keys(pattern: $"*_{userId}_*");
        }
    }
}
