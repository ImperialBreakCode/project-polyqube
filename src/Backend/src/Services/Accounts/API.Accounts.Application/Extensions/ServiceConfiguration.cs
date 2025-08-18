using API.Accounts.Application.DatabaseInit;
using API.Accounts.Application.Features.Roles.Factories;
using API.Accounts.Application.Features.Roles.Seeders;
using API.Accounts.Application.Features.Users.AuthToken.Issuer;
using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.LoginChecksChain;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Application.Features.Users.Options;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Application.Features.Users.SagaMachines.UserSoftDeleteMachine;
using API.Accounts.Application.Features.Users.Seeders;
using API.Accounts.Application.Features.Users.UrlFileResponseTransforms;
using API.Accounts.Domain.SagaMachineDatas.UserSoftDelete;
using API.Accounts.Infrastructure;
using API.Shared.Application.Extensions;
using API.Shared.Common.MediatorResponse;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Accounts.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDatabaseSeeder<DatabaseSeeder>()
                .AddFluentValidators()
                .AddMapper()
                .AddMassTransitRabbitMq(
                    configuration, 
                    typeof(ServiceConfiguration).Assembly,
                    cfg =>
                    {
                        cfg.AddTransactionalOutbox<AccountsDbContext>();
                        cfg.ConfigureSagaStateMachine<UserSoftDeletionMachine, UserSoftDeleteSagaData, AccountsDbContext>();
                    });

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
            services.AddTransient<IUserCommandFactory, UserCommandFactory>();
            services.AddTransient<ISessionQueryFactory, SessionQueryFactory>();
            services.AddTransient<ISessionCommandFactory, SessionCommandFactory>();

            services.AddTransient<IUserSeeder, UserSeeder>();

            services.AddTransient<IMediatorResponseInterceptor<UserViewModel>, UserViewModelTransform>();

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
