using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions.Chats;
using AutoMapper;

namespace API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId
{
    internal class GetProfileByUserIdQueryHandler : IQueryHandler<GetProfileByUserIdQuery, UserProfileViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProfileByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfileViewModel> Handle(GetProfileByUserIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _unitOfWork.UserProfileRepository.GetProfileByUserId(request.UserId);
            if (profile is null)
            {
                throw new ChatProfileNotFoundException();
            }

            return _mapper.Map<UserProfileViewModel>(profile);
        }
    }
}
