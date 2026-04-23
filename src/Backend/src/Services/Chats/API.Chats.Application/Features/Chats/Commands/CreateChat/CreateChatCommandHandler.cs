using API.Chats.Application.Features.Chats.Models;
using API.Chats.Domain;
using API.Chats.Domain.Factories;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions.Chats;
using AutoMapper;

namespace API.Chats.Application.Features.Chats.Commands.CreateChat
{
    internal class CreateChatCommandHandler : ICommandHandler<CreateChatCommand, ChatViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainServiceFactory _domainServiceFactory;
        private readonly IMapper _mapper;

        public CreateChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDomainServiceFactory domainServiceFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainServiceFactory = domainServiceFactory;
        }

        public async Task<ChatViewModel> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.UserProfileRepository.UserProfileExists(request.PeerProfileId)
                || !await _unitOfWork.UserProfileRepository.UserProfileExists(request.InitiatorProfileId))
            {
                throw new ChatProfileNotFoundException();
            }

            var chatDomainService = _domainServiceFactory.CreateChatDomainService();
            var chat = chatDomainService.CreatePeerChat(
                request.InitiatorProfileId,
                request.PeerProfileId,
                _unitOfWork.ChatRepository,
                _unitOfWork.ParticipantRepository);

            return _mapper.Map<ChatViewModel>(chat);
        }
    }
}
