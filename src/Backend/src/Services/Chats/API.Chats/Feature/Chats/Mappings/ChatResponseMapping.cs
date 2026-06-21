using API.Chats.Application.Features.Chats.Models;
using API.Chats.Feature.Chats.Models.Responses;
using AutoMapper;

namespace API.Chats.Feature.Chats.Mappings
{
    public class ChatResponseMapping : Profile
    {
        public ChatResponseMapping()
        {
            CreateMap<ChatViewModel, ChatResponseDTO>();
        }
    }
}
