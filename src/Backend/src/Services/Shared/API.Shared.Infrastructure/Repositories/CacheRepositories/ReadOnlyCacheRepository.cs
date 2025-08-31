using API.Shared.Domain.Interfaces.CacheRepo;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace API.Shared.Infrastructure.Repositories.CacheRepositories
{
    public class ReadOnlyCacheRepository<T> : IReadCacheRepository<T>
        where T : class
    {
        private readonly IDistributedCache _cache;

        public ReadOnlyCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        protected IDistributedCache Cache => _cache;
        protected virtual string KeyPrefix => typeof(T).Name.ToLower();

        public virtual T? Get(string key)
        {
            var jsonString = _cache.GetString($"{KeyPrefix}_{key}");

            if (jsonString is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
