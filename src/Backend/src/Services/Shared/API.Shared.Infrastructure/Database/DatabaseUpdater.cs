using API.Shared.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Shared.Infrastructure.Database
{
    internal class DatabaseUpdater<T> : IDatabaseUpdater
        where T : DbContext
    {
        private readonly DatabaseFacade _db;

        public DatabaseUpdater(T dbContext)
        {
            _db = dbContext.Database;
        }

        public async Task UpdateDatabase()
        {
            await _db.MigrateAsync();
        }
    }
}
