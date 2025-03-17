namespace API.Accounts.Common.Features.Users.Constants
{
    public static class UserValidationConfiguration
    {
        public const int USERNAME_MIN_LENGTH = 1;
        public const int USERNAME_MAX_LENGTH = 10;
        public const string USERNAME_ALLOWED_SYMBOLS_REGEX = "^[a-zA-Z0-9._]+$";

        public const string FIRST_LAST_NAMES_SYMBOLS_REGEX = "^[a-zA-Z'-]+$";
        public const int FIRST_LAST_NAMES_MIN_LENGHT = 1;
        public const int FIRST_LAST_NAMES_MAX_LENGHT = 100;
    }
}
