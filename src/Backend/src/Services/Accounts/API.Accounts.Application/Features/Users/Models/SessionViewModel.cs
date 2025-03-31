namespace API.Accounts.Application.Features.Users.Models
{
    public record SessionViewModel(string SessionId, string UserId, DateTimeOffset Expiration);
}
