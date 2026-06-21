using API.Chats.Common.Features.ChatFeatures.Constants;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;

namespace API.Chats.Application.Features.ChatFeatures.Seeders
{
    internal class ChatFeatureSeeder : IChatFeatureSeeder
    {
        public async Task SeedFeatureInfos(IChatFeatureRepository chatFeatureRepository)
        {
            await SeedChatFeature(chatFeatureRepository, ChatFeatureNames.AI_CHAT_MEMBER);
        }

        private async Task SeedChatFeature(IChatFeatureRepository chatFeatureRepository, string featureName, ChatFeatureMode featureMode = ChatFeatureMode.On)
        {
            ChatFeature? featureInfo = await chatFeatureRepository.GetByFeatureName(featureName);

            if (featureInfo is null)
            {
                featureInfo = ChatFeature.Create(featureName, featureMode);
                chatFeatureRepository.Insert(featureInfo);
            }
        }
    }
}
