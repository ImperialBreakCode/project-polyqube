using API.Shared.Domain.Interfaces.Entity;
using API.Shared.Domain.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Repositories
{
    public class SoftDeleteRepository<TEntity> : Repository<TEntity>, ISoftDeleteRepository<TEntity>
        where TEntity : class, IEntity, ISoftDeletable
    {
        public SoftDeleteRepository(DbSet<TEntity> dbSet) : base(dbSet)
        {
        }

        public TEntity? GetActiveEntityById(string id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id && x.DeletedAt == null);
        }
    }
}
