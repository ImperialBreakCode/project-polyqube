using API.Chats.Application.DatabaseInit;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace API.Chats.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddChatsApplicationLayer(this IServiceCollection services)
        {
            services
                .AddDatabaseSeeder<DatabaseSeeder>();

            return services;
        }
    }
}
