using API.Chats.Domain;
using API.Chats.Domain.Factories;
using API.Chats.Infrastructure.Factories;
using API.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Chats.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddChatsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabase<ChatDbContext>(configuration)
                .AddReadOnlyFilePathCache()
                .AddMediatRServices()
                .AddReddisServices(configuration)
                .AddMongoDbOptions();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            services.AddTransient<IDomainServiceFactory, DomainServiceFactory>();

            return services;
        }
    }
}
