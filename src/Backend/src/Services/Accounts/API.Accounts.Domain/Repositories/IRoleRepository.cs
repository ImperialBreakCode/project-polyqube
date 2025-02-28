using API.Accounts.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Accounts.Domain.Repositories
{
    public interface IRoleRepository : IRepoInsert<Role>, IRepoRead<Role>
    {
        Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Role? GetByName(string name);
        ICollection<UserRole> GetActiveUserRoles(string roleId, int startPosition, int amount);
        ICollection<UserRole> GetUserRoles(string roleId, int startPosition, int amount);
        Task<ICollection<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    }
}
