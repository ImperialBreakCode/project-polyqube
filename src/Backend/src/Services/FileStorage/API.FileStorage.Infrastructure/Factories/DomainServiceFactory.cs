using API.FileStorage.Domain.Factories;
using API.FileStorage.Domain.Services;
using Minio;

namespace API.FileStorage.Infrastructure.Factories
{
    internal class DomainServiceFactory : IDomainServiceFactory
    {
        private readonly IMinioClient _minioClient;

        public DomainServiceFactory(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public FileService CreateFileService()
        {
            return new FileService(_minioClient);
        }
    }
}
