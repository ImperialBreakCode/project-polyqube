using API.Shared.Application.DatabaseInit;

namespace API.Chats.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        public Task SeedDatabase()
        {
            return Task.CompletedTask;
        }
    }
}
