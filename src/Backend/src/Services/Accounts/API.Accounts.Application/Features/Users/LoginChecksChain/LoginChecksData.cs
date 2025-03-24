using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.LoginChecksChain
{
    internal class LoginChecksData
    {
        private LoginChecksData() { }

        private LoginChecksData(User user, string requestPassword)
        {
            User = user;
            RequestPassword = requestPassword;
        }

        public User User { get; init; }
        public string RequestPassword { get; init; }

        public static LoginChecksData Create(User user, string requestPassword)
        {
            return new LoginChecksData(user, requestPassword);
        }
    }
}
