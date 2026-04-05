using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.UserProfiles.Exceptions
{
    public class UserAlreadyBlockedException : BadRequestException
    {
        private const string MESSAGE = "This profile is already blocked";

        public UserAlreadyBlockedException() : base(MESSAGE)
        {
        }
    }
}
