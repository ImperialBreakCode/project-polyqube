namespace API.Shared.Application.Contracts.Emails.Commands
{
    public record SendEmailVerification(string Email, string Token);
}
