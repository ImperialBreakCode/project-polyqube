using API.Accounts.Application.Features.Users.Options;
using API.Shared.Application.Auth.AuthTokenVerifier;
using API.Shared.Common.Constants;
using API.Shared.Web.Auth;
using API.Shared.Web.ExceptionHandler;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
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
                .AddAppExceptionHandler()
                .AddAPIAuthentication();
                
            services.AddControllers();

            return services;
        }

        private static IServiceCollection AddAPIAuthentication(this IServiceCollection services)
        {
            services.AddTransient<IAuthTokenVerifier, AuthTokenVerifier>();

            services
                .AddOptions<AuthTokenOptions>()
                .BindConfiguration(nameof(AuthTokenOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();


            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = APIAuthSchemeNames.APIDefaultAuthScheme;
                    options.DefaultChallengeScheme = APIAuthSchemeNames.APIDefaultAuthScheme;
                })
                .AddScheme<AuthenticationSchemeOptions, APIAuthenticationHandler>(APIAuthSchemeNames.APIDefaultAuthScheme, null);

            return services;
        }

        private static IServiceCollection AddVersioning(this IServiceCollection services)
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

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        private static IServiceCollection AddAppExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
