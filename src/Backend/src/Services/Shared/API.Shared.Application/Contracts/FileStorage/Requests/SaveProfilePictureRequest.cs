namespace API.Shared.Application.Contracts.FileStorage.Requests
{
    public record SaveProfilePictureRequest(string FileName, string MimeType, byte[] ByteContent);
}
