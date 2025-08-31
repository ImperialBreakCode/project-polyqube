using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure.Features.EmailVerificationTokens
{
    internal class EmailVerificationTokenRepository : Repository<EmailVerificationToken>, IGenericTokenRepository<EmailVerificationToken>
    {
        public EmailVerificationTokenRepository(DbSet<EmailVerificationToken> dbSet) : base(dbSet)
        {
        }

        public override EmailVerificationToken? GetById(string id)
        {
            return DbSet.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<EmailVerificationToken?> GetTokenByTokenValueAsync(string tokenValue)
        {
            return await DbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.Token == tokenValue);
        }
    }
}
