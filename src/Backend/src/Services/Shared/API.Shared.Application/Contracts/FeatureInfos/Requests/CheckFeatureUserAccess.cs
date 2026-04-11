namespace API.Shared.Application.Contracts.FeatureInfos.Requests
{
    public record CheckFeatureUserAccess(string UserId, string FeatureName)
    {
        public static CheckFeatureUserAccess Create(string userId, string featureName) 
            => new(userId, featureName);
    }
}
