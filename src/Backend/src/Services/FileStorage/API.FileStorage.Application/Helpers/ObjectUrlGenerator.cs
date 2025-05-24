using API.FileStorage.Common.Constants;
using API.FileStorage.Domain.Factories;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;

namespace API.FileStorage.Application.Helpers
{
    internal class ObjectUrlGenerator : IObjectUrlGenerator
    {
        private readonly ICacheRepository<FilePathCache> _cacheRepository;
        private readonly IDomainServiceFactory _domainServiceFactory;

        public ObjectUrlGenerator(ICacheRepository<FilePathCache> cacheRepository, IDomainServiceFactory domainServiceFactory)
        {
            _cacheRepository = cacheRepository;
            _domainServiceFactory = domainServiceFactory;
        }

        public async Task<string> GenerateObjectUrl(string path, string bucketName, int expirySeconds = MinioConstants.DefaultUrlExpirySeconds)
        {
            var fileService = _domainServiceFactory.CreateFileService();

            var url = await fileService.GetPresignedUrlAsync(bucketName, path, expirySeconds);
            _cacheRepository.Set(path, FilePathCache.Create(path, url), DateTimeOffset.UtcNow.AddSeconds(expirySeconds));

            return url;
        }
    }
}
