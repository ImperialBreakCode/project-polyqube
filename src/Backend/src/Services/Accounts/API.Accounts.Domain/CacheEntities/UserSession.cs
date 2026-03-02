namespace API.Accounts.Domain.CacheEntities
{
    public class UserSession
    {
        private UserSession() { }

        private UserSession(string sessionId, string userId, string refreshTokenId, string accessTokenId, DateTimeOffset expiration)
        {
            SessionId = sessionId;
            UserId = userId;
            Expiration = expiration;
            AccessTokenId = accessTokenId;
            RefreshTokenId = refreshTokenId;
        }

        public string SessionId { get; set; }
        public string RefreshTokenId { get; set; }
        public string AccessTokenId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public static UserSession Create(string sessionId, string userId, string refreshTokenId, string accessTokenId, DateTimeOffset expiration)
        {
            return new UserSession(sessionId, userId, refreshTokenId, accessTokenId, expiration);
        }
    }
}
