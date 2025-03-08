namespace API.Shared.Application.Auth.AuthTokenVerifier
{
    public interface IAuthTokenVerifier
    {
        IDictionary<string, object> VerifyToken(string token);
    }
}
