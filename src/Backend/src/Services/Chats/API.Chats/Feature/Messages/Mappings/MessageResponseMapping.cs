using API.Chats.Application.Features.Messages.Models;
using API.Chats.Feature.Messages.Models.Responses;
using AutoMapper;

namespace API.Chats.Feature.Messages.Mappings
{
    public class MessageResponseMapping : Profile
    {
        public MessageResponseMapping()
        {
            CreateMap<MessageViewModel, MessageResponseDTO>();
        }
    }
}
