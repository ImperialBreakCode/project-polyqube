using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName
{
    internal class SearchProfilesByFullNameQueryHandler : IQueryHandler<SearchProfilesByFullNameQuery, SearchProfilesByFullNameResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchProfilesByFullNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SearchProfilesByFullNameResponse> Handle(SearchProfilesByFullNameQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _unitOfWork.UserProfileRepository
                .SearchProfilesByFullName(request.ProfileName, request.CurrentProfileId, request.Count);

            return new SearchProfilesByFullNameResponse(_mapper.Map<ICollection<UserProfileViewModel>>(profiles));
        }
    }
}
