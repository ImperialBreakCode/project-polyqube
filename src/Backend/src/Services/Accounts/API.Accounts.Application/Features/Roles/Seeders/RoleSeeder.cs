using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Common.Constants;

namespace API.Accounts.Application.Features.Roles.Seeders
{
    internal class RoleSeeder : IRoleSeeder
    {
        public void SeedRoles(IRoleRepository roleRepository)
        {
            SeedRole(roleRepository, AccountRoleNames.SUPERUSER_ROLE);
            SeedRole(roleRepository, AccountRoleNames.ADMIN_ROLE);
            SeedRole(roleRepository, AccountRoleNames.USER_ROLE);
        }

        private void SeedRole(IRoleRepository roleRepository, string roleName)
        {
            Role? role = roleRepository.GetByName(roleName);

            if (role is null)
            {
                role = Role.Create(roleName);
                roleRepository.Insert(role);
            }
        }
    }
}
