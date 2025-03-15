using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Commands.CreateUserDetails;
using API.Accounts.Application.Features.Users.Commands.LoginUser;
using API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens;
using API.Accounts.Application.Features.Users.Commands.ValidateAccessToken;
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

            CreateMap<ValidateAccessTokenRequestDTO, ValidateAccessTokenCommand>();
            CreateMap<RefreshAuthTokensRequestDTO, RefreshAuthTokensCommand>();

            CreateMap<(CreateUserDetailsRequestDTO, string), CreateUserDetailsCommand>()
                .ConstructUsing(x => new(x.Item2, x.Item1.FirstName, x.Item1.LastName, x.Item1.Birthdate, x.Item1.Gender));
        }
    }
}
