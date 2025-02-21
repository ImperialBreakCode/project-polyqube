using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces.Repo.BaseInterfaces
{
    public interface IRepoUpdate<TEntity> where TEntity : class, IEntity
    {
        void Update(TEntity entity);
    }
}
