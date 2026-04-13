using API.Chats.Application.Features.Chats.Commands.CreateChat;

namespace API.Chats.Application.Features.Chats.Factories
{
    public interface IChatCommandFactory
    {
        CreateChatCommand CreateChatCommand(string initiatorProfileId, string peerProfileId);
    }
}
