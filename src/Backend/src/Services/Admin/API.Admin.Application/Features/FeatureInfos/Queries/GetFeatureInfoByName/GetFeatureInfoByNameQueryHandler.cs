using API.Admin.Application.Features.FeatureInfos.Models;
using API.Admin.Common.Features.FeatureInfo.Exceptions;
using API.Admin.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Admin.Application.Features.FeatureInfos.Queries.GetFeatureInfoByName
{
    internal class GetFeatureInfoByNameQueryHandler : IQueryHandler<GetFeatureInfoByNameQuery, FeatureInfoViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFeatureInfoByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FeatureInfoViewModel> Handle(GetFeatureInfoByNameQuery request, CancellationToken cancellationToken)
        {
            var featureInfo = await _unitOfWork.FeatureInfoRepository.GetByFeatureNameAsync(request.FeatureName);
            if (featureInfo is null)
            {
                throw new FeatureNotFoundException();
            }

            return _mapper.Map<FeatureInfoViewModel>(featureInfo);
        }
    }
}
