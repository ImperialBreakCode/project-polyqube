using API.Chats.Application.Features.Chats.Commands.CreateChat;

namespace API.Chats.Application.Features.Chats.Factories
{
    internal class ChatCommandFactory : IChatCommandFactory
    {
        public CreateChatCommand CreateChatCommand(string initiatorProfileId, string peerProfileId)
        {
            return new CreateChatCommand(initiatorProfileId, peerProfileId);
        }
    }
}
