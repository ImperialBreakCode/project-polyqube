using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.UserProfiles.Exceptions
{
    public class ProfileAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "Profile already exists";

        public ProfileAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
