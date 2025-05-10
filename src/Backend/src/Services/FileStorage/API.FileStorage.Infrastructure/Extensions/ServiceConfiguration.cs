using API.FileStorage.Infrastructure.Features.FilePaths;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.FileStorage.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddReddisServices(configuration);

            services.AddTransient<ICacheRepository<FilePathCache>, FilePathCacheRepository>();

            return services;
        }
    }
}
