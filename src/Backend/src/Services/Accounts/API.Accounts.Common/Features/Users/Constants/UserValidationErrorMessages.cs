namespace API.Accounts.Common.Features.Users.Constants
{
    public static class UserValidationErrorMessages
    {
        public const string USERNAME_LENGTH_ERROR = "The length of the username should be between 1 and 10 symbols.";
        public const string USERNAME_ALLOWED_SYMBOLS_ERROR = "Username can only contain numbers, letters, dashes and dots.";

        public const string FIRST_LAST_NAMES_LENGTH_ERROR = "The length of the first and the last name should be between 1 and 100 characters.";
        public const string FIRST_LAST_NAMES_ALLOWED_SYMBOLS_ERROR = "First and last names can only contain letters, dashes and apostrophes.";
    }
}
