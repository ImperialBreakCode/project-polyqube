using API.Accounts.Application.Features.Roles.Interfaces;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Common.Constants;

namespace API.Accounts.Application.Features.Roles
{
    internal class RoleSeeder : IRoleSeeder
    {
        public void SeedRoles(IRoleRepository roleRepository)
        {
            Role? adminRole = roleRepository.GetByName(AccountRoleNames.ADMIN_ROLE);

            if (adminRole is null)
            {
                adminRole = Role.Create(AccountRoleNames.ADMIN_ROLE);
                roleRepository.Insert(adminRole);
            }

            Role? userRole = roleRepository.GetByName(AccountRoleNames.USER_ROLE);

            if (userRole is null)
            {
                userRole = Role.Create(AccountRoleNames.USER_ROLE);
                roleRepository.Insert(userRole);
            }
        }
    }
}
