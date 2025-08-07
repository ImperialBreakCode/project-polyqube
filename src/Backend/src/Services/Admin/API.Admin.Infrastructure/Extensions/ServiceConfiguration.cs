using API.Admin.Domain;
using API.Admin.Infrastructure.Factories;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Admin.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabase<AdminDbContext>(configuration)
                .AddMediatRServices();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            return services;
        }
    }
}
