using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Infrastructure.Repositories.CacheRepositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;

namespace API.Shared.Infrastructure.Repositories.FileStorage
{
    public class FilePathReadOnlyCache : ReadOnlyCacheRepository<FilePathCache>
    {
        public FilePathReadOnlyCache(IDistributedCache cache) : base(cache)
        {
        }

        public override FilePathCache? Get(string key)
        {
            return base.Get(Base64UrlEncoder.Encode(key));
        }
    }
}
