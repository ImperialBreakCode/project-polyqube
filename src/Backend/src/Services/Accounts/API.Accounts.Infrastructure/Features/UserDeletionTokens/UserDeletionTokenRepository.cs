using API.Accounts.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure.Features.UserDeletionTokens
{
    internal class UserDeletionTokenRepository : Repository<UserDeletionToken>, IRepository<UserDeletionToken>
    {
        public UserDeletionTokenRepository(DbSet<UserDeletionToken> dbSet) : base(dbSet)
        {
        }

        public override UserDeletionToken? GetById(string id)
        {
            return DbSet.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }
    }
}
