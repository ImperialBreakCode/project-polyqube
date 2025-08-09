using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Factories;
using API.Shared.Domain.Base;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Infrastructure
{
    internal class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        private readonly AccountsDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IRepository<UserDeletionToken> _userDeletionTokenRepository;

        public UnitOfWork(AccountsDbContext context, IRepositoryFactory repositoryFactory)
            : base(context)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public IUserRepository UserRepository 
            => _userRepository ??= _repositoryFactory.CreateUserRepository(_context);

        public IRoleRepository RoleRepository 
            => _roleRepository ??= _repositoryFactory.CreateRoleRepository(_context);

        public IRepository<UserDeletionToken> UserDeletionRepository
            => _userDeletionTokenRepository ??= _repositoryFactory.CreateUserDeletionTokenRepository(_context);
    }
}
