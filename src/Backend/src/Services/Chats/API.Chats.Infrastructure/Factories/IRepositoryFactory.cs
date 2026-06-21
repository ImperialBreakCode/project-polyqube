using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Infrastructure.Factories
{
    internal interface IRepositoryFactory
    {
        IUserProfileRepository CreateUserProfileRepository(ChatDbContext dbContext);
        IChatFeatureRepository CreateChatFeatureRepository(ChatDbContext dbContext);
        IChatAgentRepository CreateChatAgentRepository(ChatDbContext dbContext);
        ISoftDeleteRepository<Chat> CreateChatRepository(ChatDbContext dbContext);
        IMessageRepository CreateMessageRepository(ChatDbContext dbContext);
        IParticipantRepository CreateParticipantRepository(ChatDbContext dbContext);
    }
}
