using API.Accounts.Common.Features.Users.Exceptions.SessionExceptions;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.ModuleLogout
{
    internal class ModuleLogoutCommandHandler : ICommandHandler<ModuleLogoutCommand>
    {
        private readonly ISessionAccessInfoRepository _sessionAccessInfoRepository;

        public ModuleLogoutCommandHandler(ISessionAccessInfoRepository sessionAccessInfoRepository)
        {
            _sessionAccessInfoRepository = sessionAccessInfoRepository;
        }

        public Task Handle(ModuleLogoutCommand request, CancellationToken cancellationToken)
        {
            var sessionAccessInfo = _sessionAccessInfoRepository.GetSessionInfo(request.SessionId, request.UserId);
            if (sessionAccessInfo is null)
            {
                throw new InvalidSessionException();
            }

            sessionAccessInfo.AccessModules = sessionAccessInfo.AccessModules
                .Where(moduleName => moduleName != request.ServiceName)
                .ToArray();
            _sessionAccessInfoRepository.SetSessionAccess(sessionAccessInfo);

            return Task.CompletedTask;
        }
    }
}
