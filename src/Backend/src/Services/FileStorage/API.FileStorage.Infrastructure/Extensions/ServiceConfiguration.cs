using API.FileStorage.Infrastructure.Features.FilePaths;
using API.FileStorage.Infrastructure.Options;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace API.FileStorage.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddReddisServices(configuration)
                .AddMinioBlobStorage(configuration);

            services.AddTransient<ICacheRepository<FilePathCache>, FilePathCacheRepository>();

            return services;
        }

        private static IServiceCollection AddMinioBlobStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<MinioOptions>()
                .BindConfiguration(nameof(MinioOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var minioOptions = configuration.GetSection(nameof(MinioOptions)).Get<MinioOptions>()!;

            services.AddMinio(config =>   
                config
                    .WithEndpoint(minioOptions.Endpoint)
                    .WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey)
                    .Build());

            return services;
        }
    }
}
