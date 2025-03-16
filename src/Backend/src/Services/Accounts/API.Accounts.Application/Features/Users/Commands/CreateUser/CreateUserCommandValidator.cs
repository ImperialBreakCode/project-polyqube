using API.Accounts.Common.Features.Users.Constants;
using FluentValidation;

namespace API.Accounts.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(UserValidationConfiguration.USERNAME_MIN_LENGTH)
                .MaximumLength(UserValidationConfiguration.USERNAME_MAX_LENGTH)
                .WithMessage(UserValidationErrorMessages.USERNAME_LENGTH_ERROR)
                .Matches(UserValidationConfiguration.USERNAME_ALLOWED_SYMBOLS_REGEX)
                .WithMessage(UserValidationErrorMessages.USERNAME_ALLOWED_SYMBOLS_ERROR);

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
