using API.Chats.Application.Features.Messages.Queries.GetMessageHistory;
using API.Chats.Feature.Messages.Models.Requests;
using AutoMapper;

namespace API.Chats.Feature.Messages.Mappings
{
    public class MessageRequestMapping : Profile
    {
        public MessageRequestMapping()
        {
            CreateMap<MessageHistoryRequestDTO, GetMessageHistoryQuery>();
        }
    }
}
