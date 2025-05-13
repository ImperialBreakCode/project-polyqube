using MassTransit;

namespace API.Shared.Application.Contracts.FileStorage.Requests
{
    public record SaveProfilePictureRequest(string FileName, string MimeType, MessageData<byte[]> ByteContent, string AccountId);
}
