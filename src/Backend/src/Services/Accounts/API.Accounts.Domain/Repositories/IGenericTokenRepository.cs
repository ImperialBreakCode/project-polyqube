using API.Shared.Domain.Base.Entity;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Accounts.Domain.Repositories
{
    public interface IGenericTokenRepository<TTokenEntity> : IRepository<TTokenEntity>
        where TTokenEntity : BaseCreatedAtEntity
    {
        Task<TTokenEntity?> GetTokenByTokenValueAsync(string tokenValue);
        Task RemoveExpiredTokens();
    }
}
