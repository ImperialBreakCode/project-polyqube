using API.Admin.Domain;
using API.Admin.Domain.Repositories;
using API.Admin.Infrastructure.Factories;
using API.Shared.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Admin.Infrastructure
{
    internal class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        private readonly AdminDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        private IFeatureInfoRepository _featureInfoRepository;

        public UnitOfWork(AdminDbContext dbContext, IRepositoryFactory repositoryFactory)
            : base(dbContext)
        {
        }

        public IFeatureInfoRepository FeatureInfoRepository 
            => _featureInfoRepository ??= _repositoryFactory.CreateFeatureInfoRepository(_context);
    }
}
