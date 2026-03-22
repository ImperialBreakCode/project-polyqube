namespace API.Accounts.Application.Features.Users.AuthToken.Issuer
{
    internal class IssuerResult
    {
        private IssuerResult() { }

        private IssuerResult(string token, DateTimeOffset expiration, string sessionId, string tokenId)
        {
            Token = token;
            Expiration = expiration;
            SessionId = sessionId;
            TokenId = tokenId;
        }

        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }

        public static IssuerResult Create(string token, DateTimeOffset expiration, string sessionId, string tokenId)
        {
            return new IssuerResult(token, expiration, sessionId, tokenId);
        }
    }
}
