using API.Chats.Application.DatabaseInit;
using API.Chats.Application.Features.ChatAgents.Seeders;
using API.Chats.Application.Features.ChatFeatures.Seeders;
using API.Chats.Application.Features.Chats.Factories;
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
                .AddUserProfiles()
                .AddChats();

            return services;
        }

        private static IServiceCollection AddChats(this IServiceCollection services)
        {
            services.AddTransient<IChatQueryFactory, ChatQueryFactory>();

            return services;
        }

        private static IServiceCollection AddUserProfiles(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileCommandFactory, UserProfileCommandFactory>();
            services.AddTransient<IUserProfileQueryFactory, UserProfileQueryFactory>();

            return services;
        }

        private static IServiceCollection AddChatFeatures(this IServiceCollection services)
        {
            services.AddTransient<IChatFeatureSeeder, ChatFeatureSeeder>();
            services.AddTransient<IChatCommandFactory, ChatCommandFactory>();

            return services;
        }

        private static IServiceCollection AddChatAgents(this IServiceCollection services)
        {
            services.AddTransient<IChatAgentSeeder, ChatAgentSeeder>();

            return services;
        }
    }
}
