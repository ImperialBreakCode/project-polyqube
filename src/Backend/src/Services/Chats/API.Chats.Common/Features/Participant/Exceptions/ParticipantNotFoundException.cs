using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.Participant.Exceptions
{
    public class ParticipantNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Chat participant not found";
        public ParticipantNotFoundException() : base(MESSAGE)
        {
        }
    }
}
