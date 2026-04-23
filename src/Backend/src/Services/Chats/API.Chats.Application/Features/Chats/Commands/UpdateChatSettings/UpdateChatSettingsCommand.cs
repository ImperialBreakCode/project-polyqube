using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Chats.Commands.UpdateChatSettings
{
    public record UpdateChatSettingsCommand(string ChatId, bool? AIEnabled = null) : ICommand;
}
