using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId
{
    internal class DeleteSessionsByUserIdCommandHandler : ICommandHandler<DeleteSessionsByUserIdCommand>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;
        private readonly ISessionAccessInfoRepository _sessionAccessInfoRepository;

        public DeleteSessionsByUserIdCommandHandler(ICacheSessionRepository cacheSessionRepository, ISessionAccessInfoRepository sessionAccessInfoRepository)
        {
            _cacheSessionRepository = cacheSessionRepository;
            _sessionAccessInfoRepository = sessionAccessInfoRepository;
        }

        public Task Handle(DeleteSessionsByUserIdCommand request, CancellationToken cancellationToken)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(request.UserId);
            _sessionAccessInfoRepository.DeleteAllSessionAccessInfosByUser(request.UserId);

            return Task.CompletedTask;
        }
    }
}
