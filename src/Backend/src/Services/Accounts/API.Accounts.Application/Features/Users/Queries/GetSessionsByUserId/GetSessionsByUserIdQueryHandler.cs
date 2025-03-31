using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Queries.GetSessionsByUserId
{
    internal class GetSessionsByUserIdQueryHandler : IQueryHandler<GetSessionsByUserIdQuery, ICollection<SessionViewModel>>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;
        private readonly IMapper _mapper;

        public GetSessionsByUserIdQueryHandler(ICacheSessionRepository cacheSessionRepository, IMapper mapper)
        {
            _cacheSessionRepository = cacheSessionRepository;
            _mapper = mapper;
        }

        public Task<ICollection<SessionViewModel>> Handle(GetSessionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var sessions = _cacheSessionRepository.GetAllSessionsByUser(request.UserId);
            var sessionViewModel = _mapper.Map<ICollection<SessionViewModel>>(sessions);

            return Task.FromResult(sessionViewModel);
        }
    }
}
