using API.Accounts.Application.Features.Users.Options;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.Repositories;
using API.Shared.Common.Constants;
using Microsoft.Extensions.Options;

namespace API.Accounts.Application.Features.Users.Seeders
{
    internal class UserSeeder : IUserSeeder
    {
        private readonly IOptionsMonitor<InitialSuperAdminOptions> _options;
        private readonly IPasswordManager _passwordManager;

        public UserSeeder(IOptionsMonitor<InitialSuperAdminOptions> options, IPasswordManager passwordManager)
        {
            _options = options;
            _passwordManager = passwordManager;
        }

        public async Task SeedUsers(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            var superuserRole = await roleRepository.GetByNameAsync(AccountRoleNames.SUPERUSER_ROLE);

            if (superuserRole == null)
            {
                throw new InvalidOperationException("Superuser role does not exist.");
            }

            var userRoles = await roleRepository.GetUserRolesAsync(superuserRole.Id, 0, 1);
            if (userRoles.Count == 0)
            {
                var passHash = _passwordManager.HashPassword(_options.CurrentValue.Password);
                var user = User.Create(_options.CurrentValue.Username, passHash, _options.CurrentValue.Email);
                userRepository.Insert(user);
                userRepository.AddUserRole(user.Id, superuserRole.Id);
            }
        }
    }
}
