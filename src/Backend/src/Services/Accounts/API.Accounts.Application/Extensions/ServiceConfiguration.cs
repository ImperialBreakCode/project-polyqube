﻿using API.Accounts.Application.DatabaseInit;
using API.Accounts.Application.Features.Roles.Factories;
using API.Accounts.Application.Features.Roles.Seeders;
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

            services.AddTransient<IRoleSeeder, RoleSeeder>();
            services.AddTransient<IRoleQueryFactory, RoleQueryFactory>();

            return services;
        }
    }
}
