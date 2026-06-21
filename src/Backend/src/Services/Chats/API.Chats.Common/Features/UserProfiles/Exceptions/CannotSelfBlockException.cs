using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.UserProfiles.Exceptions
{
    public class CannotSelfBlockException : BadRequestException
    {
        private const string MESSAGE = "Cannot selfblock";

        public CannotSelfBlockException() : base(MESSAGE)
        {
        }
    }
}
