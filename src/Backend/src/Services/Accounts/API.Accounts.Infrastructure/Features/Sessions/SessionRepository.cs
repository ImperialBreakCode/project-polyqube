using API.Accounts.Domain.CacheEntities;
using API.Shared.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace API.Accounts.Infrastructure.Features.Sessions
{
    internal class SessionRepository : CacheRepository<UserSession>
    {
        public SessionRepository(IDistributedCache cache) : base(cache)
        {
        }

        protected override string KeyPrefix => "session";
    }
}
