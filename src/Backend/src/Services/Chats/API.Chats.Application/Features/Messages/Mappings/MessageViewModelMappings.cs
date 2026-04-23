using API.Chats.Application.Features.Messages.Models;
using API.Chats.Domain.Aggregates;
using AutoMapper;

namespace API.Chats.Application.Features.Messages.Mappings
{
    public class MessageViewModelMappings : Profile
    {
        public MessageViewModelMappings()
        {
            CreateMap<Message, MessageViewModel>();
        }
    }
}
