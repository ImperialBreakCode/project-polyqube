using API.Accounts.Domain.Repositories;
using API.Shared.Application.Contracts.Accounts.Commands;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class RevokeUserSessionsConsumer : IConsumer<RevokeUserSessions>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;

        public RevokeUserSessionsConsumer(ICacheSessionRepository cacheSessionRepository)
        {
            _cacheSessionRepository = cacheSessionRepository;
        }

        public Task Consume(ConsumeContext<RevokeUserSessions> context)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(context.Message.UserId);

            return Task.CompletedTask;
        }
    }
}
