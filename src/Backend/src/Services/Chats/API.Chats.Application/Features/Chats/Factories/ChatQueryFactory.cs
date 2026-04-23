using API.Chats.Application.Features.Chats.Queries.GetProfileChats;

namespace API.Chats.Application.Features.Chats.Factories
{
    internal class ChatQueryFactory : IChatQueryFactory
    {
        public GetProfileChatsQuery CreateGetProfileChatsQuery(string profileId)
        {
            return new GetProfileChatsQuery(profileId);
        }
    }
}
