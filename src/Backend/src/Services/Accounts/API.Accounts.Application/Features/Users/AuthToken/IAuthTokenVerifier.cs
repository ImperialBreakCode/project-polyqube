namespace API.Accounts.Application.Features.Users.AuthToken
{
    internal interface IAuthTokenVerifier
    {
        IDictionary<string, object> VerifyToken(string token);
    }
}
