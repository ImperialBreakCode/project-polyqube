using API.Chats.Application.DatabaseInit;
using API.Chats.Application.Features.ChatAgents.Seeders;
using API.Chats.Application.Features.ChatFeatures.Seeders;
using API.Chats.Application.Features.UserProfiles.Factories;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Chats.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddChatsApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabaseSeeder<DatabaseSeeder>()
                .AddMapper()
                .AddMassTransitRabbitMq(configuration, typeof(ServiceConfiguration).Assembly);

            services
                .AddChatFeatures()
                .AddChatAgents()
                .AddUserProfiles();

            return services;
        }

        private static IServiceCollection AddUserProfiles(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileCommandFactory, UserProfileCommandFactory>();

            return services;
        }

        private static IServiceCollection AddChatFeatures(this IServiceCollection services)
        {
            services.AddTransient<IChatFeatureSeeder, ChatFeatureSeeder>();

            return services;
        }

        private static IServiceCollection AddChatAgents(this IServiceCollection services)
        {
            services.AddTransient<IChatAgentSeeder, ChatAgentSeeder>();

            return services;
        }
    }
}
