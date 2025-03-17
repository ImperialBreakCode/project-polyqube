namespace API.Accounts.Application.Features.Users.PasswordManager
{
    internal interface IPasswordManager
    {
        string HashPassword(string password);
        public bool VerifyPassword(string password, string hash);
    }
}
