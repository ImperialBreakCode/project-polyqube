﻿using API.Shared.Web.ExceptionHandler;
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace API.Shared.Web.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureWebServices(this IServiceCollection services)
        {
            services
                .AddVersioning()
                .AddSwagger()
                .AddAppExceptionHandler();
                
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static IServiceCollection AddAppExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
