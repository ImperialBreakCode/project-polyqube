using API.Shared.Infrastructure.Interceptors;
using API.Shared.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                .ValidateOnStart();

            services.AddDbContext<TDbContext>(options =>
            {
                var databaseOptions = configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();

                options.UseSqlServer(databaseOptions.ConnectionString);

                options.AddInterceptors(new AuditInterceptor());
            });

            return services;
        }
    }
}
