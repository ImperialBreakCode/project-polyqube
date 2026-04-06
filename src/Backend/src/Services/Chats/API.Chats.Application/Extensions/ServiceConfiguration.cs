using API.Chats.Application.DatabaseInit;
using API.Chats.Application.Features.ChatFeatures.Seeders;
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

            services
                .AddChatFeatures();

            return services;
        }

        private static IServiceCollection AddChatFeatures(this IServiceCollection services)
        {
            services.AddTransient<IChatFeatureSeeder, ChatFeatureSeeder>();

            return services;
        }
    }
}
