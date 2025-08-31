namespace API.Shared.Application.Contracts.FileStorage.Results
{
    public record FilePathResult(string? Path = null) {

        public static FilePathResult SuccessResult(string path) => new(path); 

        public static FilePathResult FailResult => new();
    }
}
