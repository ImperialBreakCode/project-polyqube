using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Domain.Repositories;

public interface IUserRepository : ISoftDeleteRepository<User>
{
    User? GetUserByUsername(string username, bool includeDeleted = default);
    User? GetUserByEmail(string email, bool includeDeleted = default);
    void AddUserRole(string userId, string roleId);
    void RemoveUserRole(UserRole userRole);
    ICollection<UserRole> GetUserRoles(string userId);
}
