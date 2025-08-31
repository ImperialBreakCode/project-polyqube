namespace API.Shared.Common.Exceptions.Email
{
    public class CouldNotSendEmailException : InternalServerError
    {
        private const string MESSAGE = "Could not send email to {0}";

        public CouldNotSendEmailException(string toEmail) : base(string.Format(MESSAGE, toEmail))
        {
        }
    }
}
