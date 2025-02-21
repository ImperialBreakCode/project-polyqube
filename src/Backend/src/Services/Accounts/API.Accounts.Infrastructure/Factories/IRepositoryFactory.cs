using API.Accounts.Domain.Repositories;

namespace API.Accounts.Infrastructure.Factories
{
    internal interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository(AccountsDbContext dbContext);
        IRoleRepository CreateRoleRepository(AccountsDbContext dbContext);
    }
}
