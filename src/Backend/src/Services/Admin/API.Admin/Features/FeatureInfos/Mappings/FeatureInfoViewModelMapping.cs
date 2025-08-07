using API.Admin.Application.Features.FeatureInfos.Models;
using API.Admin.Features.FeatureInfos.Models.Responses;
using AutoMapper;

namespace API.Admin.Features.FeatureInfos.Mappings
{
    public class FeatureInfoViewModelMapping : Profile
    {
        public FeatureInfoViewModelMapping()
        {
            CreateMap<FeatureInfoViewModel, FeatureInfoResponseDTO>();
        }
    }
}
