using API.Chats.Application.Features.Chats.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Chats.Commands.CreateChat
{
    public record CreateChatCommand(string InitiatorProfileId, string PeerProfileId) : ICommand<ChatViewModel>;
}
