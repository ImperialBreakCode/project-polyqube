using API.Chats.Domain.DomainServices;

namespace API.Chats.Domain.Factories
{
    public interface IDomainServiceFactory
    {
        ChatDomainService CreateChatDomainService();
    }
}
