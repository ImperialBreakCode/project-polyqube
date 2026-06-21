using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.Chats.Exceptions
{
    public class ChatNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Chat not found";
        public ChatNotFoundException() : base(MESSAGE)
        {
        }
    }
}
