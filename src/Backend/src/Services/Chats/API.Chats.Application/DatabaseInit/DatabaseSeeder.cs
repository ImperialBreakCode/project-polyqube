using API.Chats.Application.Features.ChatAgents.Seeders;
using API.Chats.Application.Features.ChatFeatures.Seeders;
using API.Chats.Domain;
using API.Shared.Application.DatabaseInit;

namespace API.Chats.Application.DatabaseInit
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IChatFeatureSeeder _chatFeatureSeeder;
        private readonly IChatAgentSeeder _chatAgentSeeder;
        private readonly IUnitOfWork _unitOfWork;

        public DatabaseSeeder(IChatFeatureSeeder chatFeatureSeeder, IUnitOfWork unitOfWork, IChatAgentSeeder chatAgentSeeder)
        {
            _chatFeatureSeeder = chatFeatureSeeder;
            _unitOfWork = unitOfWork;
            _chatAgentSeeder = chatAgentSeeder;
        }

        public async Task SeedDatabase()
        {
            await _chatFeatureSeeder.SeedFeatureInfos(_unitOfWork.ChatFeatureRepository);
            await _chatAgentSeeder.SeedChatAgents(_unitOfWork.ChatAgentRepository);
            _unitOfWork.Save();
        }
    }
}
