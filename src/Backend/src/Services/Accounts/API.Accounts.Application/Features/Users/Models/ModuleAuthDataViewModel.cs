namespace API.Accounts.Application.Features.Users.Models
{
    public record ModuleAuthDataViewModel(
        string Code,
        string RefreshToken,
        string AccessToken,
        string UserId,
        string SessionId,
        string ModuleName,
        DateTimeOffset Expiration);
}
