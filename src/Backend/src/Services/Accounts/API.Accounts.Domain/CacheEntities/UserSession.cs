namespace API.Accounts.Domain.CacheEntities
{
    public class UserSession
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public TimeSpan Expiration { get; set; }
    }
}
