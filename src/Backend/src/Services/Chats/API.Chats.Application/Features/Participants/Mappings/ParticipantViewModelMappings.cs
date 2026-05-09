using API.Chats.Application.Features.Participants.Models;
using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using AutoMapper;

namespace API.Chats.Application.Features.Participants.Mappings
{
    internal class ParticipantViewModelMappings : Profile
    {
        public ParticipantViewModelMappings()
        {
            CreateMap<UserProfile, ParticipantUserProfileViewModel>();
            CreateMap<ChatAgent, ParticipantChatAgentViewModel>();
            CreateMap<Participant, ParticipantViewModel>();
        }
    }
}
