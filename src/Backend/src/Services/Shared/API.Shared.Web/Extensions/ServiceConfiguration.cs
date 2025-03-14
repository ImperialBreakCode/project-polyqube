using API.Shared.Common.Constants;
using API.Shared.Web.Auth.Authentication;
using API.Shared.Web.Auth.Authorization;
using API.Shared.Web.ExceptionHandler;
using API.Shared.Web.Factories;
using API.Shared.Web.Options;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Shared.Web.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddMainWebServices(this IServiceCollection services)
        {
            services
                .AddVersioning()
                .AddSwagger()
                .AddAppExceptionHandler();
                
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddHttpAuthenticationHandler(this IServiceCollection services)
        {
            services.AddTransient<IAuthFactory, AuthFactory>();
            services.AddTransient<IAccessTokenValidator, HttpAccessTokenValidator>();

            services
                .AddOptions<AuthValidationOptions>()
                .BindConfiguration(nameof(AuthValidationOptions))
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

        public static IServiceCollection AddAuthorizationPolices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolices.USER_ROLE_POLICY, policy 
                    => policy.AddRequirements(new RoleRequirement(AccountRoleNames.USER_ROLE)));

                options.AddPolicy(AuthorizationPolices.ADMIN_ROLE_POLICY, policy
                    => policy.AddRequirements(new RoleRequirement(AccountRoleNames.ADMIN_ROLE)));
            });

            services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(APIAuthSchemeNames.APIDefaultAuthScheme, new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Enter JWT token:",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = APIAuthSchemeNames.APIDefaultAuthScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

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

        private static IServiceCollection AddAppExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
