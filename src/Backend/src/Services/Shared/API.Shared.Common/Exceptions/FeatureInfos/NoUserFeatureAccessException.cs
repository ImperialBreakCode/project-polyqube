namespace API.Shared.Common.Exceptions.FeatureInfos
{
    public class NoUserFeatureAccessException : BadRequestException
    {
        private const string MESSAGE = "User has no access to this service at the moment.";
        public NoUserFeatureAccessException() : base(MESSAGE)
        {
        }
    }
}
