using API.Accounts.Application.Features.Roles.Models;
using API.Accounts.Domain.Aggregates;
using AutoMapper;

namespace API.Accounts.Application.Features.Roles.Mappings
{
    public class RolesQueryMappings : Profile
    {
        public RolesQueryMappings() 
        {
            CreateMap<Role, RoleQueryViewModel>();
        }
    }
}
