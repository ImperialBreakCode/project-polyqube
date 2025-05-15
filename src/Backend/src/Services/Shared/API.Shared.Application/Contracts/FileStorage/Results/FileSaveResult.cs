namespace API.Shared.Application.Contracts.FileStorage.Results
{
    public record FileSaveResult {

        public FileSaveResult()
        {
            
        }

        public FileSaveResult(bool success, string? path = null)
        {
            Success = success;
            Path = path;
        }

        public bool Success { get; set; }
        public string? Path { get; set; }

        public static FileSaveResult SuccessResult(string path) => new(true, path); 
        public static FileSaveResult FailResult => new(false);
    }
}
