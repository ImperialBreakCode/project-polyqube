using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Features.EmailVerificationTokens;
using API.Accounts.Infrastructure.Features.Roles;
using API.Accounts.Infrastructure.Features.UserDeletionTokens;
using API.Accounts.Infrastructure.Features.Users;

namespace API.Accounts.Infrastructure.Factories
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IGenericTokenRepository<EmailVerificationToken> CreateEmailVerificationTokenRepository(AccountsDbContext dbContext)
        {
            return new EmailVerificationTokenRepository(dbContext.EmailVerificationTokens);
        }

        public IRoleRepository CreateRoleRepository(AccountsDbContext dbContext)
        {
            return new RoleRepository(dbContext);
        }

        public IGenericTokenRepository<UserDeletionToken> CreateUserDeletionTokenRepository(AccountsDbContext dbContext)
        {
            return new UserDeletionTokenRepository(dbContext.UserDeletionTokens);
        }

        public IUserRepository CreateUserRepository(AccountsDbContext dbContext)
        {
            return new UserRepository(dbContext);
        }
    }
}
