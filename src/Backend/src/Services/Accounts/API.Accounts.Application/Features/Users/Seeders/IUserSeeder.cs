using API.Accounts.Domain.Repositories;

namespace API.Accounts.Application.Features.Users.Seeders
{
    internal interface IUserSeeder
    {
        Task SeedUsers(IUserRepository userRepository, IRoleRepository roleRepository);
    }
}
