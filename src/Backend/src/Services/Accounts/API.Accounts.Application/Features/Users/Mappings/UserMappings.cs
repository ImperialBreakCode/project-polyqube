using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.Aggregates.UserAggregate;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
