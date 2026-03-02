namespace API.Shared.Domain.CacheEntities.Accounts
{
    public class SessionAccessInfo
    {
        private SessionAccessInfo()
        {
        }

        private SessionAccessInfo(string[] accessModules, string userId, DateTimeOffset expiration, string sessionId)
        {
            AccessModules = accessModules;
            UserId = userId;
            Expiration = expiration;
            SessionId = sessionId;
        }

        public string[] AccessModules { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public static SessionAccessInfo Create(string[] accessModules, string userId, DateTimeOffset expiration, string sessionId)
        {
            return new SessionAccessInfo(accessModules, userId, expiration, sessionId);
        }
    }
}
