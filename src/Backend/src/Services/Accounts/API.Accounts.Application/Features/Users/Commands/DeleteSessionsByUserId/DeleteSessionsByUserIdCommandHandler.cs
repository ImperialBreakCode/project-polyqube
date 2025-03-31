using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId
{
    internal class DeleteSessionsByUserIdCommandHandler : ICommandHandler<DeleteSessionsByUserIdCommand>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;

        public DeleteSessionsByUserIdCommandHandler(ICacheSessionRepository cacheSessionRepository)
        {
            _cacheSessionRepository = cacheSessionRepository;
        }

        public Task Handle(DeleteSessionsByUserIdCommand request, CancellationToken cancellationToken)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(request.UserId);

            return Task.CompletedTask;
        }
    }
}
