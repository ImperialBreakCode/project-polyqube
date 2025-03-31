namespace API.Accounts.Application.Features.Users.Models;

public record UserEmailViewModel(string Email, bool IsPrimary, bool IsVerified, DateTime CreatedAt, DateTime UpdatedAt);
