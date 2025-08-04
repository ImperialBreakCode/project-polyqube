using API.Shared.Common.Exceptions;

namespace API.Admin.Common.Features.FeatureInfo.Exceptions
{
    public class TestUserAlreadyExists : ConflictException
    {
        private const string MESSAGE = "This user is already a feature test user";

        public TestUserAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
