using API.Chats.Common.Features.ChatAgents.Constants;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;

namespace API.Chats.Application.Features.ChatAgents.Seeders
{
    internal class ChatAgentSeeder : IChatAgentSeeder
    {
        public async Task SeedChatAgents(IChatAgentRepository chatAgentRepository)
        {
            // System AI Chat Member
            await SeedChatAgent(chatAgentRepository, AIMemberConstants.AGENT_NAME, AIMemberConstants.AGENT_USERNAME);
        }

        private async Task SeedChatAgent(IChatAgentRepository chatAgentRepository, string agentName, string agentUsername)
        {
            ChatAgent? chatAgent = await chatAgentRepository.GetByUsername(agentUsername);

            if (chatAgent == null)
            {
                chatAgent = ChatAgent.Create(agentName, agentUsername);
                chatAgentRepository.Insert(chatAgent);
            }
        }
    }
}
