using API.Shared.Application.DatabaseInit;
using Microsoft.Extensions.DependencyInjection;

namespace API.Shared.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDatabaseSeeder<TDatabaseSeeder>(this IServiceCollection services)
            where TDatabaseSeeder : class, IDatabaseSeeder
        {
            services.AddTransient<IDatabaseSeeder, TDatabaseSeeder>();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceConfiguration).Assembly);

            return services;
        }
    }
}
