using API.Accounts.Application.DatabaseInit;
using API.Accounts.Application.Features.Roles.Factories;
using API.Accounts.Application.Features.Roles.Seeders;
using API.Accounts.Application.Features.Users.AuthToken.Issuer;
using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.LoginChecksChain;
using API.Accounts.Application.Features.Users.Options;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Application.Features.Users.Seeders;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace API.Accounts.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsApplicationLayer(this IServiceCollection services)
        {
            services
                .AddDatabaseSeeder<DatabaseSeeder>()
                .AddFluentValidators()
                .AddMapper();

            services
                .AddRoles()
                .AddUsers();

            return services;
        }

        private static IServiceCollection AddUsers(this IServiceCollection services)
        {
            services
                .AddOptions<AuthTokenOptions>()
                .BindConfiguration(nameof(AuthTokenOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services
                .AddOptions<InitialSuperAdminOptions>()
                .BindConfiguration(nameof(InitialSuperAdminOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddTransient<IAuthTokenIssuer, AuthTokenIssuer>();
            services.AddTransient<IAuthTokenVerifier, AuthTokenVerifier>();
            services.AddTransient<IPasswordManager, PasswordManager>();
            services.AddTransient<ILoginChecksChainManager, LoginChecksChainManager>();
            services.AddTransient<IViewModelFactory, ViewModelFactory>();
            services.AddTransient<IUserQueryFactory, UserQueryFactory>();
            services.AddTransient<ISessionQueryFactory, SessionQueryFactory>();
            services.AddTransient<IUserSeeder, UserSeeder>();

            return services;
        }

        private static IServiceCollection AddRoles(this IServiceCollection services)
        {
            services.AddTransient<IRoleSeeder, RoleSeeder>();
            services.AddTransient<IRoleQueryFactory, RoleQueryFactory>();

            return services;
        }
    }
}
