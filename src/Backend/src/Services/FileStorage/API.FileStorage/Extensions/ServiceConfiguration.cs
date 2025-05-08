using API.Shared.Web.Extensions;

namespace API.FileStorage.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTelemetry("api-file-storage", configuration);

            return services;
        }
    }
}
