using API.Shared.Application.DatabaseInit;
using API.Shared.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Shared.Web.Extensions
{
    public static class DatabaseInitializer
    {
        public static async Task<IHost> SeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var dbUpdater = scope.ServiceProvider.GetRequiredService<IDatabaseUpdater>();
                await dbUpdater.UpdateDatabase();

                var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
                await seeder.SeedDatabase();
            }

            return host;
        }
    }
}
