using API.Shared.Domain.Interfaces.Entity;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;

namespace API.Shared.Domain.Interfaces.Repo
{
    public interface IRepository<TEntity> : IRepoDelete<TEntity>, IRepoRead<TEntity>, IRepoInsert<TEntity>, IRepoUpdate<TEntity> 
        where TEntity : class, IEntity
    {
    }
}
