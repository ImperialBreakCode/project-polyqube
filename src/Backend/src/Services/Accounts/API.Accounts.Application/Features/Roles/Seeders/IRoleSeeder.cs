using API.Accounts.Domain.Repositories;

namespace API.Accounts.Application.Features.Roles.Seeders
{
    internal interface IRoleSeeder
    {
        void SeedRoles(IRoleRepository roleRepository);
    }
}
