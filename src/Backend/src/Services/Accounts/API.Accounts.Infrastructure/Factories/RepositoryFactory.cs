using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Features.Roles;
using API.Accounts.Infrastructure.Features.Users;

namespace API.Accounts.Infrastructure.Factories
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IRoleRepository CreateRoleRepository(AccountsDbContext dbContext)
        {
            return new RoleRepository(dbContext);
        }

        public IUserRepository CreateUserRepository(AccountsDbContext dbContext)
        {
            return new UserRepository(dbContext);
        }
    }
}
