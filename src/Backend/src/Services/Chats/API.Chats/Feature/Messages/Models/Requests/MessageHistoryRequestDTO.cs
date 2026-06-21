using System.ComponentModel.DataAnnotations;

namespace API.Chats.Feature.Messages.Models.Requests
{
    public record MessageHistoryRequestDTO
    {
        [Required]
        public string ChatId { get; init; }

        [Required]
        public int Count { get; init; }

        [Required]
        public int Offset { get; init; }
    }
}
