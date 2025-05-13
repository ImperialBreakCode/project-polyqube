namespace API.Shared.Application.Contracts.FileStorage.Results
{
    public record FileOperationResult {

        private FileOperationResult(bool success, string? message = null)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }

        public static FileOperationResult SuccessResult => new(true); 
        public static FileOperationResult FailResult(string message) => new(false, message);
    }
}
