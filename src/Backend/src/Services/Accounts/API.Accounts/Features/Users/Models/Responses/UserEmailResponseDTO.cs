namespace API.Accounts.Features.Users.Models.Responses
{
    public record UserEmailResponseDTO(string Email, bool IsPrimary, bool IsVerified, DateTime CreatedAt, DateTime UpdatedAt);
}
