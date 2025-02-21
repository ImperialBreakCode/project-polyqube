using API.Shared.Domain.Interfaces.Entity;
using API.Shared.Domain.Interfaces.Repo.BaseInterfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Repositories
{
    public class InsertReadRepository<TEntity> : IRepoInsert<TEntity>, IRepoRead<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        protected DbSet<TEntity> DbSet => _dbSet;

        public InsertReadRepository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public virtual TEntity? GetById(string id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }
    }
}
