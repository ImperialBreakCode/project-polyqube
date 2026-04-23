using API.Chats.Domain.Repositories;

namespace API.Chats.Application.Features.ChatFeatures.Seeders
{
    internal interface IChatFeatureSeeder
    {
        Task SeedFeatureInfos(IChatFeatureRepository chatFeatureRepository);
    }
}
