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

            return services;
        }
    }
}
