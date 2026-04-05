using API.Shared.Web.Extensions;

namespace API.Chats.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddChatsPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMainWebServices()
                .AddCorsPolicies(configuration)
                .AddTelemetry("api-chats", configuration);

            return services;
        }
    }
}
