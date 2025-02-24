using API.Accounts.Domain.Repositories;

namespace API.Accounts.Application.Features.Roles.Interfaces
{
    internal interface IRoleSeeder
    {
        void SeedRoles(IRoleRepository roleRepository);
    }
}
