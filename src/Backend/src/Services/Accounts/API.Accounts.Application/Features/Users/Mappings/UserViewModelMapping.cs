using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.Aggregates.UserAggregate;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class UserViewModelMapping : Profile
    {
        public UserViewModelMapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserEmail, UserEmailViewModel>();
            CreateMap<UserDetails, UserDetailsViewModel>();
        }
    }
}
