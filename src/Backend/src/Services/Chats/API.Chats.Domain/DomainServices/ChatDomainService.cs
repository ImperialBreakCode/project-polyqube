using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Repositories;
using API.Shared.Domain.Interfaces.Repo;

namespace API.Chats.Domain.DomainServices
{
    public class ChatDomainService
    {
        public async Task<Chat> CreatePeerChat(
            string initiatorProfileId,
            string peerProfileId,
            ISoftDeleteRepository<Chat> chatRepo, 
            IParticipantRepository participantRepo)
        {
            if (await participantRepo.PeerChatExistsForUsers(initiatorProfileId, peerProfileId))
            {
                throw new PeerChatAlreadyExistsException();
            }

            Chat chat = Chat.Create();
            Participant initiator = Participant.CreateUserParticipant(chat.Id, initiatorProfileId);
            Participant peer = Participant.CreateUserParticipant(chat.Id, peerProfileId);

            chatRepo.Insert(chat);
            participantRepo.Insert(initiator);
            participantRepo.Insert(peer);

            return chat;
        }
    }
}
