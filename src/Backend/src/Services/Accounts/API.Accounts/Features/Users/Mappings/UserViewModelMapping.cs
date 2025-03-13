using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Features.Users.Models.Responses;
using AutoMapper;

namespace API.Accounts.Features.Users.Mappings
{
    public class UserViewModelMapping : Profile
    {
        public UserViewModelMapping()
        {
            CreateMap<UserViewModel, UserResponseDTO>();
            CreateMap<UserEmailViewModel, UserEmailResponseDTO>();
            CreateMap<UserDetailsViewModel, UserDetailsResponseDTO>();

            CreateMap<AuthTokensViewModel, LoginResponseDTO>();
            CreateMap<AuthTokensViewModel, RefreshAuthTokensResponseDTO>();
            CreateMap<AuthTokenValidationViewModel, AccessTokenPayloadResponseDTO>();
        }
    }
}
