namespace API.Accounts.Domain.CacheEntities
{
    public class ModuleAuthData
    {
        private ModuleAuthData()
        {
        }

        private ModuleAuthData(
            string code, 
            string 
            refreshToken, 
            string accessToken,
            string userId, 
            string sessionId,
            string moduleName,
            DateTimeOffset expiration)
        {
            Code = code;
            RefreshToken = refreshToken;
            AccessToken = accessToken;
            UserId = userId;
            SessionId = sessionId;
            ModuleName = moduleName;
            Expiration = expiration;
        }

        public string Code { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public string ModuleName { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public static ModuleAuthData Create(
            string
            refreshToken,
            string accessToken,
            string userId,
            string sessionId,
            string moduleName)
        {
            return new ModuleAuthData(
                Guid.NewGuid().ToString(), 
                refreshToken, 
                accessToken, 
                userId, 
                sessionId, 
                moduleName, 
                DateTimeOffset.UtcNow.AddMinutes(3));
        }
    }
}
