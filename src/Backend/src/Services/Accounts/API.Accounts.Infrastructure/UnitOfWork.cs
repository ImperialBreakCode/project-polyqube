using API.Accounts.Domain;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Factories;

namespace API.Accounts.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AccountsDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UnitOfWork(AccountsDbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public IUserRepository UserRepository 
            => _userRepository ??= _repositoryFactory.CreateUserRepository(_context);

        public IRoleRepository RoleRepository 
            => _roleRepository ??= _repositoryFactory.CreateRoleRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
