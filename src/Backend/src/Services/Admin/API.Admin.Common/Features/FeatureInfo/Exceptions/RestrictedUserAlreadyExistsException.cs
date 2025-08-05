using API.Shared.Common.Exceptions;

namespace API.Admin.Common.Features.FeatureInfo.Exceptions
{
    public class RestrictedUserAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "This user is already feature restricted";

        public RestrictedUserAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
