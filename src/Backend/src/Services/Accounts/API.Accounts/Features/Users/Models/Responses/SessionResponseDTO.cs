namespace API.Accounts.Features.Users.Models.Responses
{
    public record SessionResponseDTO(string SessionId, string UserId, DateTimeOffset Expiration);
}
