using API.Shared.Application.DatabaseInit;
using FluentValidation;
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
