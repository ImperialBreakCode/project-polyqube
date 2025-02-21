using API.Accounts.Domain.DomainServices;

namespace API.Accounts.Domain.Factories
{
    public interface IDomainServiceFactory
    {
        UserDomainService CreateUserDomainService();
    }
}
