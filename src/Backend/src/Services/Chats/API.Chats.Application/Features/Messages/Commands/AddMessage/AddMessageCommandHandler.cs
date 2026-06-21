using API.Chats.Application.Features.Messages.Models;
using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Common.Features.Participant.Exceptions;
using API.Chats.Domain;
using API.Chats.Domain.Aggregates;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.Messages.Commands.AddMessage
{
    internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand, MessageViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageViewModel> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = _unitOfWork.ChatRepository.GetById(request.ChatId);
            if (chat is null)
            {
                throw new ChatNotFoundException();
            }

            if (request.AuthorType == AuthorType.ChatAgent && !chat.AIEnabled)
            {
                throw new ChatFunctionalityNotEnabled();
            }

            Participant? participant = null;
            if (request.AuthorType == AuthorType.ChatAgent)
            {
                participant = await _unitOfWork.ParticipantRepository
                    .GetChatParticipantByChatAgentId(request.AuthorId, request.ChatId);
            }
            else
            {
                participant = await _unitOfWork.ParticipantRepository
                    .GetChatParticipantByProfileId(request.AuthorId, request.ChatId);
            }

            if (participant is null)
            {
                throw new ParticipantNotFoundException();
            }

            MessageType messageType = request.AuthorType == AuthorType.ChatAgent
                ? MessageType.AgentMessage
                : MessageType.Normal;

            var message = Message.Create(request.TextContent, request.ChatId, messageType);
            message.ParticipantId = participant?.Id;

            _unitOfWork.MessageRepository.Insert(message);
            _unitOfWork.Save();

            return _mapper.Map<MessageViewModel>(message);
        }
    }
}
