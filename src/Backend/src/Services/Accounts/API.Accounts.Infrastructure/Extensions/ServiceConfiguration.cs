using API.Accounts.Domain;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Factories;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Factories;
using API.Accounts.Infrastructure.Features.ModuleAuthDatas;
using API.Accounts.Infrastructure.Features.SessionAccessInfos;
using API.Accounts.Infrastructure.Features.Sessions;
using API.Shared.Domain.CacheEntities.Accounts;
using API.Shared.Domain.Interfaces.CacheRepo;
using API.Shared.Infrastructure.Extensions;
using API.Shared.Infrastructure.Repositories.CacheRepositories;
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
                .AddReadOnlyFilePathCache()
                .AddMediatRServices()
                .AddReddisServices(configuration)
                .AddMongoDbOptions();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            services.AddTransient<IDomainServiceFactory, DomainServiceFactory>();

            services.AddTransient<ICacheRepository<UserSession>, SessionRepository>();
            services.AddTransient<ICacheSessionRepository, SessionRepositoryAdapter>();

            services.AddTransient<ICacheRepository<SessionAccessInfo>, CacheRepository<SessionAccessInfo>>();
            services.AddTransient<ISessionAccessInfoRepository, SessionAccessInfoRepoAdapter>();

            services.AddTransient<ICacheRepository<ModuleAuthData>, CacheRepository<ModuleAuthData>>();
            services.AddTransient<IModuleAuthDataRepository, ModuleAuthDataRepoAdapter>();

            return services;
        }
    }
}
