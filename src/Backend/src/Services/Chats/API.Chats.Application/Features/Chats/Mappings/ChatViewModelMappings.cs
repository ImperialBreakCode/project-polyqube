using API.Chats.Application.Features.Chats.Models;
using API.Chats.Domain.Aggregates;
using AutoMapper;

namespace API.Chats.Application.Features.Chats.Mappings
{
    internal class ChatViewModelMappings : Profile
    {
        public ChatViewModelMappings()
        {
            CreateMap<Chat, ChatViewModel>();
        }
    }
}
