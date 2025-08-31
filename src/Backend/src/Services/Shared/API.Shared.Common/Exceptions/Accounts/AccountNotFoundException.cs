namespace API.Shared.Common.Exceptions.Accounts
{
    public class AccountNotFoundException : NotFoundException
    {
        private const string MESSAGE = "User not found";

        public AccountNotFoundException() : base(MESSAGE)
        {
        }
    }
}
