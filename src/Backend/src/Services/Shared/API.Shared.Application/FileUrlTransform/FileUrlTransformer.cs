using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Contracts.FileStorage.Results;
using API.Shared.Common.Exceptions;
using API.Shared.Common.FileUrlTransform;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using MassTransit;

namespace API.Shared.Application.FileUrlTransform
{
    public abstract class FileUrlTransformer<T> : IFileUrlTransformer<T>
        where T : class
    {
        private readonly IRequestClient<GenerateAccountsFileUrlRequest> _requestClient;
        private readonly IReadCacheRepository<FilePathCache> _readFileCacheRepository;

        protected FileUrlTransformer(
            IRequestClient<GenerateAccountsFileUrlRequest> requestClient, 
            IReadCacheRepository<FilePathCache> readFileCacheRepository)
        {
            _requestClient = requestClient;
            _readFileCacheRepository = readFileCacheRepository;
        }

        public abstract Task TransformUrl(T model);

        protected async Task<string> GetUrlPath(string path)
        {
            var url = _readFileCacheRepository.Get(path);
            if (url is not null)
            {
                return url.PresignedUrl;
            }

            var result = await _requestClient.GetResponse<FilePathResult>(new(path));
            if (!result.Message.Success)
            {
                throw new InternalServerError();
            }

            return result.Message.Path!;
        }
    }
}
