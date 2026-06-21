using System.ComponentModel.DataAnnotations;

namespace API.Chats.Feature.Chats.Models.Requests
{
    public record CreatePeerChatRequestDTO
    {
        [Required]
        public string PeerProfileId { get; init; }
    }
}
