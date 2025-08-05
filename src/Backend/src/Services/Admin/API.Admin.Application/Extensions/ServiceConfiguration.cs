using API.Admin.Application.DatabaseInit;
using API.Admin.Application.Features.FeatureInfos.Seeders;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Admin.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAdminApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabaseSeeder<DatabaseSeeder>()
                .AddMassTransitRabbitMq(configuration, typeof(ServiceConfiguration).Assembly)
                .AddMapper();

            services
                .AddFeatureInfos();

            return services;
        }

        private static IServiceCollection AddFeatureInfos(this IServiceCollection services)
        {
            services.AddTransient<IFeatureInfoSeeder, FeatureInfoSeeder>();

            return services;
        }
    }
}
