using API.Accounts.Application.Features.Roles.Models;
using API.Accounts.Domain.Aggregates;
using AutoMapper;

namespace API.Accounts.Application.Features.Roles.Mappings
{
    public class RolesQueryProfile : Profile
    {
        public RolesQueryProfile() 
        {
            CreateMap<Role, RoleQueryViewModel>();
        }
    }
}
