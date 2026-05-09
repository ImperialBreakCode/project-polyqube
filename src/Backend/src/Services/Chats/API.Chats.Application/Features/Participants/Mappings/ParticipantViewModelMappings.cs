using API.Chats.Application.Features.Participants.Models;
using API.Chats.Domain.Aggregates;
using AutoMapper;

namespace API.Chats.Application.Features.Participants.Mappings
{
    internal class ParticipantViewModelMappings : Profile
    {
        public ParticipantViewModelMappings()
        {
            CreateMap<Participant, ParticipantUserProfileViewModel>()
                .ForCtorParam(nameof(ParticipantUserProfileViewModel.FullName), opt => opt.MapFrom(src => src.FullName));

            CreateMap<ChatAgent, ParticipantChatAgentViewModel>();

            CreateMap<Participant, ParticipantViewModel>()
                .ForCtorParam(nameof(ParticipantViewModel.UserProfile), opt => opt.MapFrom(src => src.UserProfile))
                .ForCtorParam(nameof(ParticipantViewModel.ChatAgent), opt => opt.MapFrom(src => src.ChatAgent));
        }
    }
}
