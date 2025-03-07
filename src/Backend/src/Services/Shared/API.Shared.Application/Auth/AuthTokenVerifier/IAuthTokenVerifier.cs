namespace API.Shared.Application.Auth.AuthTokenVerifier
{
    public interface IAuthTokenVerifier
    {
        IDictionary<string, string> VerifyToken(string token);
    }
}
