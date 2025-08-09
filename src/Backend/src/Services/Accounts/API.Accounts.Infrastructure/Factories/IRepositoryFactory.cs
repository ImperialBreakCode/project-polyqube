using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Infrastructure.Factories
{
    internal interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository(AccountsDbContext dbContext);
        IRoleRepository CreateRoleRepository(AccountsDbContext dbContext);
        IRepository<UserDeletionToken> CreateUserDeletionTokenRepository(AccountsDbContext dbContext);
    }
}
