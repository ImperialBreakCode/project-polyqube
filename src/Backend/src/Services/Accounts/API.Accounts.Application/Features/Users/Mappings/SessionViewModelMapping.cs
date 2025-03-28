using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.CacheEntities;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class SessionViewModelMapping : Profile
    {
        public SessionViewModelMapping()
        {
            CreateMap<UserSession, SessionViewModel>();
        }
    }
}
