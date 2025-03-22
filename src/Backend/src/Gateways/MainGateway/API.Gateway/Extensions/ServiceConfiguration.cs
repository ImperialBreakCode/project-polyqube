using API.Shared.Web.Extensions;

namespace API.Gateway.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddGatewayPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMainWebServices()
                .AddYarpGateway(configuration)
                .AddRateLimitingPolicies();

            return services;
        }

        private static IServiceCollection AddYarpGateway(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            return services;
        }
    }
}
