using API.Shared.Application.DatabaseInit;
using API.Shared.Application.Options;
using API.Shared.Common.Constants;
using API.Shared.Infrastructure.Options;
using FluentValidation;
using MassTransit;
using MassTransit.MongoDbIntegration.MessageData;
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

        public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services, IConfiguration configuration, System.Reflection.Assembly assembly)
        {
            services
                .AddOptions<RabbitMqOptions>()
                .BindConfiguration(nameof(RabbitMqOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

            var rabbitmqOptions = configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>()!;
            var mongoDbOptions = configuration.GetSection(nameof(MongoDbOptions)).Get<MongoDbOptions>()!;

            IMessageDataRepository repository = new MongoDbMessageDataRepository(mongoDbOptions.ConnectionString, MessageBusConstants.MONGO_DB_MESSAGE_DATA_NAME);
            services.AddSingleton(repository);

            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumers(assembly);

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseMessageData(repository);

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
