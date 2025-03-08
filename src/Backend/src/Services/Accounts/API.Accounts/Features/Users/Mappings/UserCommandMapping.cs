using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Commands.LoginUser;
using API.Accounts.Features.Users.Models.Requests;
using AutoMapper;

namespace API.Accounts.Features.Users.Mappings
{
    public class UserCommandMapping : Profile
    {
        public UserCommandMapping()
        {
            CreateMap<RegisterUserRequestDTO, CreateUserCommand>();
            CreateMap<LoginUserRequestDTO, LoginUserCommand>();
        }
    }
}
