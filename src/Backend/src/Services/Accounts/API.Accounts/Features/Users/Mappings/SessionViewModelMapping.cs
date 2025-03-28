using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Features.Users.Models.Responses;
using AutoMapper;

namespace API.Accounts.Features.Users.Mappings
{
    public class SessionViewModelMapping : Profile
    {
        public SessionViewModelMapping()
        {
            CreateMap<SessionViewModel, SessionResponseDTO>();
        }
    }
}
