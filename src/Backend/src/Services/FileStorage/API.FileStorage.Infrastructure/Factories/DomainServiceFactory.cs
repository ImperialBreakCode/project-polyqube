using API.FileStorage.Domain.Factories;
using API.FileStorage.Domain.Services;
using API.FileStorage.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Minio;

namespace API.FileStorage.Infrastructure.Factories
{
    internal class DomainServiceFactory : IDomainServiceFactory
    {
        private readonly IMinioClient _minioClient;
        private readonly IOptionsMonitor<MinioOptions> _optionsMonitor;

        public DomainServiceFactory(IMinioClient minioClient, IOptionsMonitor<MinioOptions> optionsMonitor)
        {
            _minioClient = minioClient;
            _optionsMonitor = optionsMonitor;
        }

        public FileService CreateFileService()
        {
            return new FileService(_minioClient, _optionsMonitor.CurrentValue.PresignedUrlHost);
        }
    }
}
