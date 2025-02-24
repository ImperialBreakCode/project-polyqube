using API.Accounts.Application.DatabaseInit;
using API.Accounts.Application.Features.Roles;
using API.Accounts.Application.Features.Roles.Interfaces;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace API.Accounts.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAccountsApplicationLayer(this IServiceCollection services)
        {
            services.AddDatabaseSeeder<DatabaseSeeder>();
            services.AddTransient<IRoleSeeder, RoleSeeder>();

            return services;
        }
    }
}
