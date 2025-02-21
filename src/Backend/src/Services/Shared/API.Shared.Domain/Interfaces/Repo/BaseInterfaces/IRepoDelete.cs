using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces.Repo.BaseInterfaces
{
    public interface IRepoDelete<TEntity> where TEntity : class, IEntity
    {
        void Delete(TEntity entity);
    }
}
