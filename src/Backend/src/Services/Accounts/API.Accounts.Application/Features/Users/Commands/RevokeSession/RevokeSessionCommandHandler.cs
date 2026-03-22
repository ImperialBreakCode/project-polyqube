using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RevokeSession
{
    internal class RevokeSessionCommandHandler : ICommandHandler<RevokeSessionCommand>
    {
        private readonly ICacheSessionRepository _sessionRepository;
        private readonly ISessionAccessInfoRepository _sessionAccessInfo;

        public RevokeSessionCommandHandler(ICacheSessionRepository sessionRepository, ISessionAccessInfoRepository sessionAccessInfo)
        {
            _sessionRepository = sessionRepository;
            _sessionAccessInfo = sessionAccessInfo;
        }

        public Task Handle(RevokeSessionCommand request, CancellationToken cancellationToken)
        {
            _sessionRepository.DeleteSession(request.SessionId, request.UserId);
            _sessionAccessInfo.DeleteSessionAccess(request.SessionId, request.UserId);

            return Task.CompletedTask;
        }
    }
}
