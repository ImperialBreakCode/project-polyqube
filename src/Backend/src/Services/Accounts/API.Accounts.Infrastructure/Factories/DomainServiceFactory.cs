using API.Accounts.Domain.DomainServices;
using API.Accounts.Domain.Factories;

namespace API.Accounts.Infrastructure.Factories
{
    internal class DomainServiceFactory : IDomainServiceFactory
    {
        public UserDomainService CreateUserDomainService()
        {
            return new UserDomainService();
        }
    }
}
