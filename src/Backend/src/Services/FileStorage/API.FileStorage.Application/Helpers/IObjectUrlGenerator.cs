using API.FileStorage.Common.Constants;

namespace API.FileStorage.Application.Helpers
{
    public interface IObjectUrlGenerator
    {
        Task<string> GenerateObjectUrl(string path, string bucketName, int expirySeconds = MinioConstants.DefaultUrlExpirySeconds);
    }
}
