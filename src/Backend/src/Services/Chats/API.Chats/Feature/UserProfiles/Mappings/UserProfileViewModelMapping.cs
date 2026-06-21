using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Feature.UserProfiles.Models.Responses;
using AutoMapper;

namespace API.Chats.Feature.UserProfiles.Mappings
{
    public class UserProfileViewModelMapping : Profile
    {
        public UserProfileViewModelMapping()
        {
            CreateMap<UserProfileViewModel, UserProfileResponseDTO>();
        }
    }
}
