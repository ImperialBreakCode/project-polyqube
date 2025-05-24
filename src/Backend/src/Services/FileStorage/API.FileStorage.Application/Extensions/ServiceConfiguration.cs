using API.FileStorage.Application.Helpers;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.FileStorage.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var currentAssembly = typeof(Features.Accounts.Consumers.SaveProfilePictureConsumer).Assembly;

            services.AddMassTransitRabbitMq(configuration, currentAssembly);

            services.AddTransient<IObjectUrlGenerator, ObjectUrlGenerator>();

            return services;
        }
    }
}
