using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.Chats.Exceptions
{
    public class ChatFunctionalityNotEnabled : BadRequestException
    {
        private const string MESSAGE = "Chat functionality not enabled";
        public ChatFunctionalityNotEnabled() : base(MESSAGE)
        {
        }
    }
}
