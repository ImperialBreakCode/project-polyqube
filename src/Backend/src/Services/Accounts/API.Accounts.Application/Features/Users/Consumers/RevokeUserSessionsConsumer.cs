using API.Accounts.Domain.Repositories;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class RevokeUserSessionsConsumer : IConsumer<RevokeUserSessionsRequest>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;

        public RevokeUserSessionsConsumer(ICacheSessionRepository cacheSessionRepository)
        {
            _cacheSessionRepository = cacheSessionRepository;
        }

        public async Task Consume(ConsumeContext<RevokeUserSessionsRequest> context)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(context.Message.UserId);

            await context.RespondAsync(UserSessionsRevokedResponse.Create(context.Message.UserId));
        }
    }
}
