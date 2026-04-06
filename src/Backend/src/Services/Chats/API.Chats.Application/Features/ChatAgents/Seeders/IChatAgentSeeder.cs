using API.Chats.Domain.Repositories;

namespace API.Chats.Application.Features.ChatAgents.Seeders
{
    internal interface IChatAgentSeeder
    {
        Task SeedChatAgents(IChatAgentRepository chatAgentRepository);
    }
}
