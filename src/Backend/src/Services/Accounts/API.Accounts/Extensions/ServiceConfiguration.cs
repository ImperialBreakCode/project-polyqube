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
                .AddCorsPolicies(configuration);

            return services;
        }
    }
}
