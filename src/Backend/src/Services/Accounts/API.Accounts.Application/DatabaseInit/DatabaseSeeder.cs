using API.Accounts.Application.Features.Roles.Seeders;
using API.Accounts.Application.Features.Users.Seeders;
using API.Accounts.Domain;
using API.Shared.Application.DatabaseInit;

namespace API.Accounts.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleSeeder _roleSeeder;
        private readonly IUserSeeder _userSeeder;

        public DatabaseSeeder(IUnitOfWork unitOfWork, IRoleSeeder roleSeeder, IUserSeeder userSeeder)
        {
            _unitOfWork = unitOfWork;
            _roleSeeder = roleSeeder;
            _userSeeder = userSeeder;
        }

        public async Task SeedDatabase()
        {
            _roleSeeder.SeedRoles(_unitOfWork.RoleRepository);
            _unitOfWork.Save();
            
            await _userSeeder.SeedUsers(_unitOfWork.UserRepository, _unitOfWork.RoleRepository);
            _unitOfWork.Save();
        }
    }
}
