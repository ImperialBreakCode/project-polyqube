using API.Accounts.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Accounts.Domain.Repositories
{
    public interface IRoleRepository : IRepoInsert<Role>, IRepoRead<Role>
    {
        Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Role? GetByName(string name);
        Task<ICollection<UserRole>> GetActiveUserRolesAsync(string roleId, int startPosition, int amount, CancellationToken cancellationToken = default);
        Task<ICollection<UserRole>> GetUserRolesAsync(string roleId, int startPosition, int amount, CancellationToken cancellationToken = default);
        Task<ICollection<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    }
}
