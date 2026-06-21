using System.ComponentModel.DataAnnotations;

namespace API.Chats.Feature.UserProfiles.Models.Requests
{
    public record SearchProfileRequestDTO
    {
        [Required]
        [MinLength(2)]
        public string SearchTerm { get; init; }

        public int Count { get; init; } = 10;
    }
}
