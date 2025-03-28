using API.Shared.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace API.Shared.Infrastructure.Repositories
{
    public class CacheRepository<T> : ICacheRepository<T>
        where T : class
    {
        private readonly IDistributedCache _cache;

        public CacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        protected virtual string KeyPrefix => typeof(T).Name.ToLower();

        public void Delete(string key)
        {
            _cache.Remove($"{KeyPrefix}_{key}");
        }

        public void DeleteMultiple(string[] keys)
        {
            foreach (var key in keys)
            {
                Delete(key);
            }
        }

        public T? Get(string key)
        {
            var jsonString = _cache.GetString($"{KeyPrefix}_{key}");

            if (jsonString is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void Set(string key, T value, DateTimeOffset timeOffset)
        {
            var jsonString = JsonConvert.SerializeObject(value);

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = timeOffset
            };

            _cache.SetString($"{KeyPrefix}_{key}", jsonString, options);
        }
    }
}
