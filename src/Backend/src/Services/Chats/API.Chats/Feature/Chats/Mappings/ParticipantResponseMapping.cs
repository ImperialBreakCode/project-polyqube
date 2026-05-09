using API.Chats.Application.Features.Participants.Models;
using API.Chats.Feature.Chats.Models.Responses;
using AutoMapper;

namespace API.Chats.Feature.Chats.Mappings
{
    public class ParticipantResponseMapping : Profile
    {
        public ParticipantResponseMapping()
        {
            CreateMap<ParticipantUserProfileViewModel, ParticipantUserProfileResponseDTO>();
            CreateMap<ParticipantChatAgentViewModel, ParticipantChatAgentResponseDTO>();
            CreateMap<ParticipantViewModel, ParticipantResponseDTO>();
        }
    }
}
