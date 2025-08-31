namespace API.Shared.Application.Contracts.FileStorage.Requests
{
    public record GenerateAccountsFileUrlRequest(string FilePath)
    {
        public static GenerateAccountsFileUrlRequest Create(string FilePath) => new(FilePath);
    }
}
