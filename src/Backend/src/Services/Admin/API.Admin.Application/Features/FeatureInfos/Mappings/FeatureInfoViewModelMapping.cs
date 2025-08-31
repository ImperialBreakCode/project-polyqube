using API.Admin.Application.Features.FeatureInfos.Models;
using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using AutoMapper;

namespace API.Admin.Application.Features.FeatureInfos.Mappings
{
    internal class FeatureInfoViewModelMapping : Profile
    {
        public FeatureInfoViewModelMapping()
        {
            CreateMap<FeatureInfo, FeatureInfoViewModel>();
        }
    }
}
