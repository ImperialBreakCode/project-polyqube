using API.Admin.Domain.Aggregates.FeatureInfoAggregate;

namespace API.Admin.Features.FeatureInfos.Models.Responses
{
    public record FeatureInfoResponseDTO(
        string Id,
        string FeatureName,
        FeatureMode Mode,
        bool UserRestrictionsEnabled,
        DateTime UpdatedAt,
        DateTime CreatedAt
    );
}
