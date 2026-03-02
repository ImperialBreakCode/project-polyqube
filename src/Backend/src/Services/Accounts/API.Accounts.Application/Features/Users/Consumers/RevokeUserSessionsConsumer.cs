using API.Accounts.Domain.Repositories;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class RevokeUserSessionsConsumer : IConsumer<RevokeUserSessionsRequest>
    {
        private readonly ICacheSessionRepository _cacheSessionRepository;
        private readonly ISessionAccessInfoRepository _sessionAccessInfoRepository;

        public RevokeUserSessionsConsumer(ICacheSessionRepository cacheSessionRepository, ISessionAccessInfoRepository sessionAccessInfoRepository)
        {
            _cacheSessionRepository = cacheSessionRepository;
            _sessionAccessInfoRepository = sessionAccessInfoRepository;
        }

        public async Task Consume(ConsumeContext<RevokeUserSessionsRequest> context)
        {
            _cacheSessionRepository.DeleteAllSessionsByUser(context.Message.UserId);
            _sessionAccessInfoRepository.DeleteAllSessionAccessInfosByUser(context.Message.UserId);

            await context.RespondAsync(UserSessionsRevokedResponse.Create(context.Message.UserId));
        }
    }
}
