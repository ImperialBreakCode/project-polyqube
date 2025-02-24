using API.Accounts.Application.Features.Roles.Interfaces;
using API.Accounts.Domain;
using API.Shared.Application.DatabaseInit;

namespace API.Accounts.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleSeeder _roleSeeder;

        public DatabaseSeeder(IUnitOfWork unitOfWork, IRoleSeeder roleSeeder)
        {
            _unitOfWork = unitOfWork;
            _roleSeeder = roleSeeder;
        }

        public void SeedDatabase()
        {
            _roleSeeder.SeedRoles(_unitOfWork.RoleRepository);
            _unitOfWork.Save();
        }
    }
}
