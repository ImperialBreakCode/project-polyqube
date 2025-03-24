namespace API.Accounts.Domain.CacheEntities
{
    public class UserSession
    {
        private UserSession() { }

        private UserSession(string sessionId, string userId, TimeSpan expiration)
        {
            SessionId = sessionId;
            UserId = userId;
            Expiration = expiration;
        }

        public string SessionId { get; set; }
        public string UserId { get; set; }
        public TimeSpan Expiration { get; set; }

        public static UserSession Create(string sessionId, string userId, TimeSpan expiration)
        {
            return new UserSession(sessionId, userId, expiration);
        }
    }
}
