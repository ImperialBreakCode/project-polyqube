namespace API.Chats.Feature.Chats.Models.Requests
{
    public record GetChatParticipantsRequestDTO
    {
        public int? ParticipantCount { get; init; }
        public bool IncludeAgents { get; init; }
    }
}
