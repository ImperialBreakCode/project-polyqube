using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Domain;
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
            }

            _unitOfWork.Save();
        }
    }
}
