using API.Shared.Domain.Interfaces.Entity;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Repositories
{
    public class CRURepository<TEntity> : InsertReadRepository<TEntity>, IRepoUpdate<TEntity>
        where TEntity : class, IEntity
    {
        public CRURepository(DbSet<TEntity> dbSet) : base(dbSet)
        {
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
