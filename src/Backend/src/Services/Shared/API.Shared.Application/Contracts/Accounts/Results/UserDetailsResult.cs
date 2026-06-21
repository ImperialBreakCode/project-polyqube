namespace API.Shared.Application.Contracts.Accounts.Results
{
    public record UserDetailsResultData(
        string FirstName,
        string LastName,
        DateOnly Birthdate,
        string? ProfilePicturePath
    );

    public record UserDetailsResult(UserDetailsResultData? UserDetailsResultData = null)
    {
        public static UserDetailsResult SuccessResult(UserDetailsResultData data) => new(data);
        public static UserDetailsResult FailResult => new();
    }
}
