using API.Accounts.Domain;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Factories;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Factories;
using API.Accounts.Infrastructure.Features.Sessions;
using API.Shared.Domain.Interfaces;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Accounts.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabase<AccountsDbContext>(configuration)
                .AddMediatRServices()
                .AddReddisServices(configuration);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            services.AddTransient<IDomainServiceFactory, DomainServiceFactory>();

            services.AddTransient<ICacheRepository<UserSession>, SessionRepository>();
            services.AddTransient<ICacheSessionRepository, SessionRepositoryAdapter>();

            return services;
        }
    }
}
