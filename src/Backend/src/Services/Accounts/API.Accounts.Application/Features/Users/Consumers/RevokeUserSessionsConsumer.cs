using API.Accounts.Domain.Repositories;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
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

        public async Task Consume(ConsumeContext<RevokeUserSessions> context)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(context.Message.UserId);

            await context.Publish<UserSessionsRevokedEvent>(new(context.Message.UserId));
        }
    }
}
