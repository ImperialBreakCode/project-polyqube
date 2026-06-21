using System.ComponentModel.DataAnnotations;

namespace API.Chats.Feature.Chats.Models.Requests
{
    public record UpdateChatSettingsRequestDTO
    {
        [Required]
        public string ChatId { get; init; }

        public bool? AIEnabled { get; init; }
    }
}
