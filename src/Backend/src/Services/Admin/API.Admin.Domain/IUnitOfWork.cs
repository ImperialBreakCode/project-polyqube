using API.Admin.Domain.Repositories;
using API.Shared.Domain.Interfaces;

namespace API.Admin.Domain
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IFeatureInfoRepository FeatureInfoRepository { get; }
    }
}
