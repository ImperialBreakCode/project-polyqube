using API.Shared.Common.Exceptions;

namespace API.Admin.Common.Features.FeatureInfo.Exceptions
{
    public class RestrictedUserAlreadyExists : ConflictException
    {
        private const string MESSAGE = "This user is already feature restricted";

        public RestrictedUserAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
