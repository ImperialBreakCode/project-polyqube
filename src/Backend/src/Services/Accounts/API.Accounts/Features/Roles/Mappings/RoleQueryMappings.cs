using API.Accounts.Application.Features.Roles.Models;
using API.Accounts.Features.Roles.Models;
using AutoMapper;

namespace API.Accounts.Features.Roles.Mappings
{
    public class RoleQueryMappings : Profile
    {
        public RoleQueryMappings()
        {
            CreateMap<RoleQueryViewModel, RoleDTO>();
        }
    }
}
