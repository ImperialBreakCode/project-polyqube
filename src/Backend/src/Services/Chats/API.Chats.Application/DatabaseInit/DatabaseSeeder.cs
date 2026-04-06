using API.Chats.Application.Features.ChatFeatures.Seeders;
using API.Chats.Domain;
using API.Shared.Application.DatabaseInit;

namespace API.Chats.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IChatFeatureSeeder _chatFeatureSeeder;
        private readonly IUnitOfWork _unitOfWork;

        public DatabaseSeeder(IChatFeatureSeeder chatFeatureSeeder, IUnitOfWork unitOfWork)
        {
            _chatFeatureSeeder = chatFeatureSeeder;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedDatabase()
        {
            await _chatFeatureSeeder.SeedFeatureInfos(_unitOfWork.ChatFeatureRepository);
            _unitOfWork.Save();
        }
    }
}
