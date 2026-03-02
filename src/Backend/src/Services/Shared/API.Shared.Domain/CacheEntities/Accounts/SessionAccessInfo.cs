namespace API.Shared.Domain.CacheEntities.Accounts
{
    public class SessionAccessInfo
    {
        private SessionAccessInfo()
        {
        }

        private SessionAccessInfo(string[] accessModules, string userId, string sessionId, DateTimeOffset expiration)
        {
            AccessModules = accessModules;
            UserId = userId;
            SessionId = sessionId;
            Expiration = expiration;
        }

        public string[] AccessModules { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public static SessionAccessInfo Create(string[] accessModules, string userId, string sessionId, DateTimeOffset expiration)
        {
            return new SessionAccessInfo(accessModules, userId, sessionId, expiration);
        }
    }
}
