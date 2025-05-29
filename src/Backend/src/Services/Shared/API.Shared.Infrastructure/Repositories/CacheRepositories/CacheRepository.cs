using API.Shared.Domain.Interfaces.CacheRepo;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace API.Shared.Infrastructure.Repositories.CacheRepositories
{
    public class CacheRepository<T> : ReadOnlyCacheRepository<T>, ICacheRepository<T>
        where T : class
    {
        public CacheRepository(IDistributedCache cache)
            : base(cache)
        {
        }

        public virtual void Delete(string key)
        {
            Cache.Remove($"{KeyPrefix}_{key}");
        }

        public virtual void DeleteMultiple(string[] keys)
        {
            foreach (var key in keys)
            {
                Delete(key);
            }
        }

        public virtual void Set(string key, T value, DateTimeOffset timeOffset)
        {
            var jsonString = JsonConvert.SerializeObject(value);

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = timeOffset
            };

            Cache.SetString($"{KeyPrefix}_{key}", jsonString, options);
        }
    }
}
