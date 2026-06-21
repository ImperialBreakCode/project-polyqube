namespace API.Accounts.Features.Users.Models.Responses
{
    public record ModuleAccessResponseDTO(
        string Code,
        DateTimeOffset Expiration);
}
