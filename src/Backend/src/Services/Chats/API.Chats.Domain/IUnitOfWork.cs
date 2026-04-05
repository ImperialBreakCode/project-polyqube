using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Domain.Interfaces;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain
{
    public interface IUnitOfWork: IUnitOfWorkBase
    {
        IChatAgentRepository ChatAgentRepository { get; }
        IChatFeatureRepository ChatFeatureRepository { get; }
        ISoftDeleteRepository<Chat> ChatRepository { get; }
        IMessageRepository MessageRepository { get; }
        IParticipantRepository ParticipantRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
    }
}
