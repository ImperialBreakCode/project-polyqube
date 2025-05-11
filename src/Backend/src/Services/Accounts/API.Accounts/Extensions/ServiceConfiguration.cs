using API.Shared.Application.Extensions;
using API.Shared.Web.Extensions;

namespace API.Accounts.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMainWebServices()
                .AddHttpAuthenticationHandler()
                .AddAuthorizationPolices()
                .AddVersioning()
                .AddCorsPolicies(configuration)
                .AddMassTransitRabbitMq(configuration)
                .AddTelemetry("api-accounts", configuration);

            return services;
        }
    }
}
