namespace API.Chats.Feature.Chats.Models.Responses
{
    public record ParticipantUserProfileResponseDTO(
        string Id,
        string FullName,
        string? ProfilePicture
    );
}
