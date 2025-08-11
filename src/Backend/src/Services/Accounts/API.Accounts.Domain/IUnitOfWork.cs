using API.Accounts.Domain.Repositories;
using API.Shared.Domain.Interfaces;

namespace API.Accounts.Domain
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserDeletionTokenRepository UserDeletionRepository { get; }
    }
}
