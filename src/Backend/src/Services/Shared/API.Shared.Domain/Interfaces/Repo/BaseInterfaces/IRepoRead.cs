using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces.Repo.BaseInterfaces
{
    public interface IRepoRead<TEntity> where TEntity : class, IEntity
    {
        TEntity? GetById(string id);
    }
}
