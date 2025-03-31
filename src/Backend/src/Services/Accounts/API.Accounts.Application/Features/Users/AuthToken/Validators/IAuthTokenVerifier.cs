namespace API.Accounts.Application.Features.Users.AuthToken.Validators
{
    internal interface IAuthTokenVerifier
    {
        IDictionary<string, object> VerifyToken(string token);
    }
}
