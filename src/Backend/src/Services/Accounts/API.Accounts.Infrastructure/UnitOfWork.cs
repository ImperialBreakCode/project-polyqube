using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Accounts.Infrastructure.Factories;
using API.Shared.Domain.Base;

namespace API.Accounts.Infrastructure
{
    internal class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        private readonly AccountsDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IGenericTokenRepository<UserDeletionToken> _userDeletionTokenRepository;
        private IGenericTokenRepository<EmailVerificationToken> _emailVerificationTokenRepository;

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

        public IGenericTokenRepository<UserDeletionToken> UserDeletionTokenRepository
            => _userDeletionTokenRepository ??= _repositoryFactory.CreateUserDeletionTokenRepository(_context);

        public IGenericTokenRepository<EmailVerificationToken> EmailVerificationToken
            => _emailVerificationTokenRepository ??= _repositoryFactory.CreateEmailVerificationTokenRepository(_context);
    }
}
