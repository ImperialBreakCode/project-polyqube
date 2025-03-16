using API.Accounts.Application.Features.Users.Commands.UpdateUserDetails;
using API.Accounts.Domain.Aggregates.UserAggregate;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class UserCommandMapping : Profile
    {
        public UserCommandMapping()
        {
            CreateMap<UpdateUserDetailsCommand, UserDetails>();
        }
    }
}
