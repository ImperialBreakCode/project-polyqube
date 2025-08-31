using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Infrastructure.Repositories.CacheRepositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;

namespace API.FileStorage.Infrastructure.Features.FilePaths
{
    internal class FilePathCacheRepository : CacheRepository<FilePathCache>
    {
        public FilePathCacheRepository(IDistributedCache cache) : base(cache)
        {
        }

        public override void Set(string key, FilePathCache value, DateTimeOffset timeOffset)
        {
            base.Set(Base64UrlEncoder.Encode(key), value, timeOffset);
        }

        public override void Delete(string key)
        {
            base.Delete(Base64UrlEncoder.Encode(key));
        }

        public override void DeleteMultiple(string[] keys)
        {
            foreach (var key in keys)
            {
                Delete(key);
            }
        }

        public override FilePathCache? Get(string key)
        {
            return base.Get(Base64UrlEncoder.Encode(key));
        }
    }
}
