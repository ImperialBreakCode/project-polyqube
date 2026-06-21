namespace API.Shared.Common.Exceptions.Accounts
{
    public class AccountDetailsNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Account details not found";
        public AccountDetailsNotFoundException() : base(MESSAGE)
        {
        }
    }
}
