using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure.Features.UserDeletionTokens
{
    internal class UserDeletionTokenRepository : Repository<UserDeletionToken>, IGenericTokenRepository<UserDeletionToken>
    {
        public UserDeletionTokenRepository(DbSet<UserDeletionToken> dbSet) : base(dbSet)
        {
        }

        public override UserDeletionToken? GetById(string id)
        {
            return DbSet.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<UserDeletionToken?> GetTokenByTokenValueAsync(string tokenValue)
        {
            return await DbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.Token == tokenValue);
        }

        public async Task RemoveExpiredTokens()
        {
            var cutoff = DateTime.UtcNow - TimeSpan.FromMinutes(10);

            await DbSet
                .Where(x => x.Expiry < cutoff)
                .ExecuteDeleteAsync();
        }
    }
}
