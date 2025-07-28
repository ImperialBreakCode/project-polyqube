using API.Shared.Domain.Interfaces.Entity;
using API.Shared.Domain.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Repositories
{
    public class Repository<TEntity> : CRURepository<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public Repository(DbSet<TEntity> dbSet) : base(dbSet)
        {
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
