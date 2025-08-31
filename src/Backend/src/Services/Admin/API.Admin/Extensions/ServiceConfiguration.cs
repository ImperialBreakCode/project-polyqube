using API.Shared.Web.Extensions;

namespace API.Admin.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAdminPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMainWebServices()
                .AddHttpAuthenticationHandler()
                .AddAuthorizationPolices()
                .AddCorsPolicies(configuration)
                .AddVersioning()
                .AddTelemetry("api-admin", configuration);

            return services;
        }
    }
}
