﻿using API.Shared.Common.PipelineBehaviors;
using API.Shared.Infrastructure.Interceptors;
using API.Shared.Infrastructure.Options;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API.Shared.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext: DbContext
        {
            services
                .AddOptions<DatabaseOptions>()
                .BindConfiguration(nameof(DatabaseOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddDbContext<TDbContext>(options =>
            {
                var databaseOptions = configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>()!;

                options.UseSqlServer(databaseOptions.ConnectionString);

                options.AddInterceptors(new AuditInterceptor());
            });

            return services;
        }

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            return services;
        }

        public static IServiceCollection AddReddisServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<RedisOptions>()
                .BindConfiguration(nameof(RedisOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var redisOptions = configuration.GetSection(nameof(RedisOptions)).Get<RedisOptions>()!;

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisOptions.RedisHost;
                options.InstanceName = "polyqube_";
            });

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisOptions.RedisHost));

            return services;
        }
    }
}
