namespace API.Shared.Application.Contracts.Base.Results
{
    public record BasicOperationResult(bool Success)
    {
        public static BasicOperationResult SuccessResult => new(true);
        public static BasicOperationResult FailResult => new(false);
    }
}
