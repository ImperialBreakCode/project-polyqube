using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.VerifyEmail
{
    public record VerifyEmailCommand(string EmailVerificationToken) : ICommand<UserEmailViewModel>;
}
