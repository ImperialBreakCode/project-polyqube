using API.Chats.Domain.DomainServices;
using API.Chats.Domain.Factories;

namespace API.Chats.Infrastructure.Factories
{
    internal class DomainServiceFactory : IDomainServiceFactory
    {
        public ChatDomainService CreateChatDomainService()
        {
            return new ChatDomainService();
        }
    }
}
