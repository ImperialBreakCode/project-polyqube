using API.Shared.Application.DatabaseInit;
using API.Shared.Application.Options;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Shared.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDatabaseSeeder<TDatabaseSeeder>(this IServiceCollection services)
            where TDatabaseSeeder : class, IDatabaseSeeder
        {
            services.AddTransient<IDatabaseSeeder, TDatabaseSeeder>();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<RabbitMqOptions>()
                .BindConfiguration(nameof(RabbitMqOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

            var rabbitmqOptions = configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>()!;

            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumers(AppDomain.CurrentDomain.GetAssemblies());

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitmqOptions.Host, "/", h =>
                    {
                        h.Username(rabbitmqOptions.Username);
                        h.Password(rabbitmqOptions.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
