using API.Chats.Application.Features.Chats.Queries.GetProfileChats;

namespace API.Chats.Application.Features.Chats.Factories
{
    public interface IChatQueryFactory
    {
        GetProfileChatsQuery CreateGetProfileChatsQuery(string profileId);
    }
}
