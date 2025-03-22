using API.Shared.Common.Constants;
using API.Shared.Web.Auth.Authentication;
using API.Shared.Web.Auth.Authorization;
using API.Shared.Web.ExceptionHandler;
using API.Shared.Web.Factories;
using API.Shared.Web.Options;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

namespace API.Shared.Web.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddMainWebServices(this IServiceCollection services)
        {
            services
                .AddSwagger()
                .AddAppExceptionHandler();
                
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

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
                options.AddPolicy(AuthorizationPolices.USER_SCOPE_POLICY, policy 
                    => policy.AddRequirements(new RoleRequirement(AccountRoleNames.USER_ROLE)));

                options.AddPolicy(AuthorizationPolices.ADMIN_SCOPE_POLICY, policy
                    => policy.AddRequirements(new RoleRequirement(AccountRoleNames.ADMIN_ROLE, AccountRoleNames.SUPERUSER_ROLE)));
            });

            services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

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

        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<CorsOptions>()
                .BindConfiguration(nameof(CorsOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var corsOptions = configuration
                .GetSection(nameof(CorsOptions))
                .Get<CorsOptions>()!;

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy(CorsPolicies.CorsPolicy, builder =>
                {
                    builder
                        .WithOrigins(corsOptions.AllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection AddRateLimitingPolicies(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddPolicy(RateLimiterPolicies.DefaultRateLimiterPolicy, context => 
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress,
                        factory: _ => new FixedWindowRateLimiterOptions()
                        {
                            AutoReplenishment = true,
                            PermitLimit = 20,
                            QueueLimit = 5,
                            Window = TimeSpan.FromSeconds(10)
                        }));
            });

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

        private static IServiceCollection AddAppExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
