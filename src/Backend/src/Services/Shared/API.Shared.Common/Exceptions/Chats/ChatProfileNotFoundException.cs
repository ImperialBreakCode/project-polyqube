namespace API.Shared.Common.Exceptions.Chats
{
    public class ChatProfileNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Chat profile not found.";
        public ChatProfileNotFoundException() : base(MESSAGE)
        {
        }
    }
}
