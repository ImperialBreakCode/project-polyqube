using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Chats.Infrastructure.Features.ChatAgents;
using API.Chats.Infrastructure.Features.ChatFeatures;
using API.Chats.Infrastructure.Features.Messages;
using API.Chats.Infrastructure.Features.Participants;
using API.Chats.Infrastructure.Features.UserProfiles;
using API.Shared.Domain.Interfaces.Repo;
using API.Shared.Infrastructure.Repositories;

namespace API.Chats.Infrastructure.Factories
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IChatAgentRepository CreateChatAgentRepository(ChatDbContext dbContext)
        {
            return new ChatAgentRepository(dbContext.ChatAgents);
        }

        public IChatFeatureRepository CreateChatFeatureRepository(ChatDbContext dbContext)
        {
            return new ChatFeatureRepository(dbContext);
        }

        public ISoftDeleteRepository<Chat> CreateChatRepository(ChatDbContext dbContext)
        {
            return new SoftDeleteRepository<Chat>(dbContext.Chats);
        }

        public IMessageRepository CreateMessageRepository(ChatDbContext dbContext)
        {
            return new MessageRepository(dbContext.Messages);
        }

        public IParticipantRepository CreateParticipantRepository(ChatDbContext dbContext)
        {
            return new ParticipantRepository(dbContext.Participant);
        }

        public IUserProfileRepository CreateUserProfileRepository(ChatDbContext dbContext)
        {
            return new UserProfileRepository(dbContext);
        }
    }
}
