using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions.ModuleAuthExceptions;
using API.Accounts.Common.Features.Users.Exceptions.SessionExceptions;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using API.Shared.Domain.CacheEntities.Accounts;

namespace API.Accounts.Application.Features.Users.Commands.ModuleLogin
{
    internal class ModuleLoginCommandHandler : ICommandHandler<ModuleLoginCommand, AuthTokensViewModel>
    {
        private readonly ISessionAccessInfoRepository _sessionAccessInfoRepository;
        private readonly IModuleAuthDataRepository _moduleAuthDataRepository;
        private readonly IViewModelFactory _viewModelFactory;

        public ModuleLoginCommandHandler(ISessionAccessInfoRepository sessionAccessInfoRepository, IModuleAuthDataRepository moduleAuthDataRepository, IViewModelFactory viewModelFactory)
        {
            _sessionAccessInfoRepository = sessionAccessInfoRepository;
            _moduleAuthDataRepository = moduleAuthDataRepository;
            _viewModelFactory = viewModelFactory;
        }

        public Task<AuthTokensViewModel> Handle(ModuleLoginCommand request, CancellationToken cancellationToken)
        {
            ModuleAuthData? moduleAuthData = _moduleAuthDataRepository.GetAuthModuleData(request.Code);
            if (moduleAuthData is null)
            {
                throw new ModuleAuthNotFoundException();
            }

            SessionAccessInfo? sessionAccessInfo = _sessionAccessInfoRepository
                .GetSessionInfo(moduleAuthData.SessionId, moduleAuthData.UserId);
            if (sessionAccessInfo is null)
            {
                throw new InvalidSessionException();
            }

            var moduleAccessList = sessionAccessInfo.AccessModules;
            if (!moduleAccessList.Contains(moduleAuthData.ModuleName))
            {
                sessionAccessInfo.AccessModules = [..moduleAccessList, moduleAuthData.ModuleName];
                _sessionAccessInfoRepository.SetSessionAccess(sessionAccessInfo);
            }

            _moduleAuthDataRepository.DeleteAuthModuleData(moduleAuthData.Code);

            var tokensViewModel = _viewModelFactory.CreateAuthTokensViewModel(moduleAuthData.AccessToken, moduleAuthData.RefreshToken);

            return Task.FromResult(tokensViewModel);
        }
    }
}
