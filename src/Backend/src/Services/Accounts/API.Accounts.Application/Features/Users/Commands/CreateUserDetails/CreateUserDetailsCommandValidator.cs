using API.Accounts.Common.Features.Users.Constants;
using FluentValidation;

namespace API.Accounts.Application.Features.Users.Commands.CreateUserDetails
{
    internal class CreateUserDetailsCommandValidator : AbstractValidator<CreateUserDetailsCommand>
    {
        public CreateUserDetailsCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(UserValidationConfiguration.FIRST_LAST_NAMES_MIN_LENGHT)
                .MaximumLength(UserValidationConfiguration.FIRST_LAST_NAMES_MAX_LENGHT)
                .WithMessage(UserValidationErrorMessages.FIRST_LAST_NAMES_LENGTH_ERROR)
                .Matches(UserValidationConfiguration.FIRST_LAST_NAMES_SYMBOLS_REGEX)
                .WithMessage(UserValidationErrorMessages.FIRST_LAST_NAMES_ALLOWED_SYMBOLS_ERROR);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(UserValidationConfiguration.FIRST_LAST_NAMES_MIN_LENGHT)
                .MaximumLength(UserValidationConfiguration.FIRST_LAST_NAMES_MAX_LENGHT)
                .WithMessage(UserValidationErrorMessages.FIRST_LAST_NAMES_LENGTH_ERROR)
                .Matches(UserValidationConfiguration.FIRST_LAST_NAMES_SYMBOLS_REGEX)
                .WithMessage(UserValidationErrorMessages.FIRST_LAST_NAMES_ALLOWED_SYMBOLS_ERROR);
        }
    }
}
