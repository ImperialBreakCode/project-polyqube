using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using AutoMapper;

namespace API.Chats.Application.Features.UserProfiles.Mappings
{
    internal class UserProfileViewModelMapping : Profile
    {
        public UserProfileViewModelMapping()
        {
            CreateMap<UserProfile, UserProfileViewModel>();
        }
    }
}
