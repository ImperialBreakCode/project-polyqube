namespace API.Accounts.Application.Features.Users.AuthToken.Issuer
{
    internal class IssuerResult
    {
        private IssuerResult() { }

        private IssuerResult(string token, DateTimeOffset expiration, string tokenId)
        {
            Token = token;
            Expiration = expiration;
            TokenId = tokenId;
        }

        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string TokenId { get; set; }

        public static IssuerResult Create(string token, DateTimeOffset expiration, string tokenId)
        {
            return new IssuerResult(token, expiration, tokenId);
        }
    }
}
