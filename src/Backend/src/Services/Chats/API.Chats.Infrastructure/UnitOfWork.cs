using API.Chats.Domain;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Chats.Infrastructure.Factories;
using API.Shared.Domain.Base;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Infrastructure
{
    internal class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        private readonly ChatDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        private IChatAgentRepository _chatAgentRepository;
        private IChatFeatureRepository _chatFeatureRepository;
        private ISoftDeleteRepository<Chat> _chatRepository;
        private IMessageRepository _messageRepository;
        private IParticipantRepository _participantRepository;
        private IUserProfileRepository _userProfileRepository;

        public UnitOfWork(ChatDbContext context, IRepositoryFactory repositoryFactory) : base(context)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public IChatAgentRepository ChatAgentRepository 
            => _chatAgentRepository ??= _repositoryFactory.CreateChatAgentRepository(_context);

        public IChatFeatureRepository ChatFeatureRepository 
            => _chatFeatureRepository ??= _repositoryFactory.CreateChatFeatureRepository(_context);

        public ISoftDeleteRepository<Chat> ChatRepository 
            => _chatRepository ??= _repositoryFactory.CreateChatRepository(_context);

        public IMessageRepository MessageRepository 
            => _messageRepository ??= _repositoryFactory.CreateMessageRepository(_context);

        public IParticipantRepository ParticipantRepository 
            => _participantRepository ??= _repositoryFactory.CreateParticipantRepository(_context);

        public IUserProfileRepository UserProfileRepository 
            => _userProfileRepository ??= _repositoryFactory.CreateUserProfileRepository(_context);
    }
}
