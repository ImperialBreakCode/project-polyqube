using API.Chats.Common.Features.ChatAgents.Constants;
using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Domain;
using API.Chats.Domain.Aggregates;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Chats.Commands.UpdateChatSettings
{
    internal class UpdateChatSettingCommandHandler : ICommandHandler<UpdateChatSettingsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateChatSettingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateChatSettingsCommand request, CancellationToken cancellationToken)
        {
            var chat = _unitOfWork.ChatRepository.GetActiveEntityById(request.ChatId);
            if (chat is null)
            {
                throw new ChatNotFoundException();
            }

            if (request.AIEnabled.HasValue)
            {
                chat.AIEnabled = request.AIEnabled.Value;

                if (request.AIEnabled.Value)
                {
                    await EnsureAgentParticipantAsync(request.ChatId, cancellationToken);
                }
            }

            _unitOfWork.Save();
        }

        private async Task EnsureAgentParticipantAsync(string chatId, CancellationToken cancellationToken)
        {
            var agent = await _unitOfWork.ChatAgentRepository.GetByUsername(AIMemberConstants.AGENT_USERNAME);
            if (agent is null)
            {
                throw new InvalidOperationException($"Chat agent '{AIMemberConstants.AGENT_USERNAME}' is not seeded.");
            }

            var existing = await _unitOfWork.ParticipantRepository.GetChatParticipantByChatAgentId(
                agent.Id,
                chatId,
                includeDeleted: false);

            if (existing is not null)
            {
                return;
            }

            var participant = Participant.CreateAgentParticipant(chatId, agent.Id);
            _unitOfWork.ParticipantRepository.Insert(participant);
        }
    }
}
