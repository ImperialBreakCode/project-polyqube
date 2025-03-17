using API.Shared.Web.Extensions;

namespace API.Accounts.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsPresentationLayer(this IServiceCollection services)
        {
            services
                .AddMainWebServices()
                .AddHttpAuthenticationHandler()
                .AddAuthorizationPolices();

            return services;
        }
    }
}
