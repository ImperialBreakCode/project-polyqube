namespace API.Accounts.Domain.CacheEntities
{
    public class UserSession
    {
        private UserSession() { }

        private UserSession(string sessionId, string userId, DateTimeOffset expiration)
        {
            SessionId = sessionId;
            UserId = userId;
            Expiration = expiration;
        }

        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public static UserSession Create(string sessionId, string userId, DateTimeOffset expiration)
        {
            return new UserSession(sessionId, userId, expiration);
        }
    }
}
