using API.Accounts.Domain;
using API.Accounts.Domain.Factories;
using API.Accounts.Infrastructure.Factories;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Accounts.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase<AccountsDbContext>(configuration);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            services.AddTransient<IDomainServiceFactory, DomainServiceFactory>();

            return services;
        }
    }
}
