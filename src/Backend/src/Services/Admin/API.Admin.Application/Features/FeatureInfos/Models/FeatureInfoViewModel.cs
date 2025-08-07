using API.Admin.Domain.Aggregates.FeatureInfoAggregate;

namespace API.Admin.Application.Features.FeatureInfos.Models
{
    public record FeatureInfoViewModel(
        string Id, 
        string FeatureName, 
        FeatureMode Mode, 
        bool UserRestrictionsEnabled,
        DateTime UpdatedAt,
        DateTime CreatedAt
    );
}
