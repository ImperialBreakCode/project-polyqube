using API.Shared.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.FileStorage.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransitRabbitMq(configuration, System.Reflection.Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
