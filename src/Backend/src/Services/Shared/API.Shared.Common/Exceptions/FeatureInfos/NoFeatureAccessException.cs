namespace API.Shared.Common.Exceptions.FeatureInfos
{
    public class NoFeatureAccessException : BadRequestException
    {
        private const string MESSAGE = "User has no access to this service at the moment.";
        public NoFeatureAccessException() : base(MESSAGE)
        {
        }
    }
}
