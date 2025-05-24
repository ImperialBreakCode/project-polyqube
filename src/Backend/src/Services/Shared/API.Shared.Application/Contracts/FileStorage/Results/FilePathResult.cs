namespace API.Shared.Application.Contracts.FileStorage.Results
{
    public record FilePathResult(bool Success, string? Path = null) {

        public static FilePathResult SuccessResult(string path) => new(true, path); 

        public static FilePathResult FailResult => new(false);
    }
}
