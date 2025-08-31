using API.Admin.Application.Features.FeatureInfos.Commands.AddTestUser;
using API.Admin.Features.FeatureInfos.Models.Requests;
using AutoMapper;

namespace API.Admin.Features.FeatureInfos.Mappings
{
    public class FeatureInfoCommandMapping : Profile
    {
        public FeatureInfoCommandMapping()
        {
            CreateMap<AddTestUserRequestDTO, AddTestUserCommand>();
        }
    }
}
