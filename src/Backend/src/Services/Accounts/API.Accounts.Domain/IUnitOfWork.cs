using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Domain.Interfaces;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Domain
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRepository<UserDeletionToken> UserDeletionRepository { get; }
    }
}
