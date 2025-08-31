using System.ComponentModel.DataAnnotations;

namespace API.Admin.Features.FeatureInfos.Models.Requests
{
    public record AddTestUserRequestDTO
    {
        [Required]
        public string FeatureId { get; init; }

        [Required]
        public string UserId { get; init; }
    }
}
