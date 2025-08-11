using API.Accounts.Domain.Aggregates;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Domain.Repositories
{
    public interface IUserDeletionTokenRepository : IRepository<UserDeletionToken>
    {
        Task<UserDeletionToken?> GetTokenByTokenValueAsync(string tokenValue);
    }
}
