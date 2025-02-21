using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces.Repo.BaseInterfaces
{
    public interface IRepoInsert<TEntity> where TEntity : class, IEntity
    {
        void Insert(TEntity entity);
    }
}
