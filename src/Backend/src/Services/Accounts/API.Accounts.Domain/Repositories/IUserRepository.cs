using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Domain.Repositories;

public interface IUserRepository : ISoftDeleteRepository<User>
{
    User? GetUserByUsername(string username, bool isDeleted = default);
    User? GetUserByEmail(string email, bool isDeleted = default);
    void AddUserRole(string userId, string roleId);
    void RemoveUserRole(UserRole userRole);
    ICollection<UserRole> GetUserRoles(string userId);
}
