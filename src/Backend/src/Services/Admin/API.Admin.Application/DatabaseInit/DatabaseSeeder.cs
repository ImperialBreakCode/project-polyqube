using API.Admin.Application.Features.FeatureInfos.Seeders;
using API.Admin.Domain;
using API.Shared.Application.DatabaseInit;

namespace API.Admin.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IFeatureInfoSeeder _featureInfoSeeder;
        private readonly IUnitOfWork _unitOfWork;

        public DatabaseSeeder(IFeatureInfoSeeder featureInfoSeeder, IUnitOfWork unitOfWork)
        {
            _featureInfoSeeder = featureInfoSeeder;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedDatabase()
        {
            await _featureInfoSeeder.SeedFeatureInfos(_unitOfWork.FeatureInfoRepository);
            _unitOfWork.Save();
        }
    }
}
