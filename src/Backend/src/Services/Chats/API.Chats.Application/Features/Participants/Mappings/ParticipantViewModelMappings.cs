using API.Chats.Application.Features.Participants.Models;
using API.Chats.Domain.Aggregates;
using AutoMapper;

namespace API.Chats.Application.Features.Participants.Mappings
{
    internal class ParticipantViewModelMappings : Profile
    {
        public ParticipantViewModelMappings()
        {
            CreateMap<Participant, ParticipantUserProfileViewModel>();
            CreateMap<ChatAgent, ParticipantChatAgentViewModel>();
            CreateMap<Participant, ParticipantViewModel>();
        }
    }
}
