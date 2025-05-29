using MassTransit;

namespace API.Shared.Application.Contracts.FileStorage.Requests
{
    public record SaveProfilePictureRequest(string FileName, MessageData<Stream> Stream, string AccountId);
}
