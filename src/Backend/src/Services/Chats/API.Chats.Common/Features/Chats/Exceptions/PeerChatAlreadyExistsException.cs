using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.Chats.Exceptions
{
    public class PeerChatAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "Peer chat already exists";

        public PeerChatAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
