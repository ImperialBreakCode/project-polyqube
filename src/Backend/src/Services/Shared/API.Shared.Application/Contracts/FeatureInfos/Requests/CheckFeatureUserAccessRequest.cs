namespace API.Shared.Application.Contracts.FeatureInfos.Requests
{
    public record CheckFeatureUserAccessRequest(string UserId, string FeatureName)
    {
        public static CheckFeatureUserAccessRequest Create(string userId, string featureName) 
            => new(userId, featureName);
    }
}
