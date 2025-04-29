using API.Shared.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Domain.Base
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        private readonly DbContext _dbContext;

        public UnitOfWorkBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
