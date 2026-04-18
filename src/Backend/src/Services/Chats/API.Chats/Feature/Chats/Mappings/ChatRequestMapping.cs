using API.Chats.Application.Features.Chats.Commands.UpdateChatSettings;
using API.Chats.Feature.Chats.Models.Requests;
using AutoMapper;

namespace API.Chats.Feature.Chats.Mappings
{
    public class ChatRequestMapping : Profile
    {
        public ChatRequestMapping()
        {
            CreateMap<UpdateChatSettingsRequestDTO, UpdateChatSettingsCommand>();
        }
    }
}
