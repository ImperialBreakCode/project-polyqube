using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces.Repo
{
    public interface ISoftDeleteRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, ISoftDeletable
    {
        TEntity? GetActiveEntityById(int id);
    }
}
