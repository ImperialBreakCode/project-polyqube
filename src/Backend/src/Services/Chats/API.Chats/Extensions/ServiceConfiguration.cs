using API.Shared.Common.Constants;
using API.Shared.Web.Extensions;

namespace API.Chats.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddChatsPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMainWebServices()
                .AddHttpAuthenticationHandler()
                .AddAuthorizationPolices(FeatureInfoNames.CHAT_SERVICE)
                .AddVersioning()
                .AddCorsPolicies(configuration)
                .AddTelemetry("api-chats", configuration);

            services.AddSignalR();

            return services;
        }
    }
}
