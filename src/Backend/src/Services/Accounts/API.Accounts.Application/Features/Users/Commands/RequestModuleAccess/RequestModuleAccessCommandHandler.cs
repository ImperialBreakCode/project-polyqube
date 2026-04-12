using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Commands.RequestModuleAccess
{
    internal class RequestModuleAccessCommandHandler : ICommandHandler<RequestModuleAccessCommand, ModuleAuthDataViewModel>
    {
        private readonly IModuleAuthDataRepository _moduleAuthRepository;
        private readonly IMapper _mapper;

        public RequestModuleAccessCommandHandler(IModuleAuthDataRepository moduleAuthRepository, IMapper mapper)
        {
            _moduleAuthRepository = moduleAuthRepository;
            _mapper = mapper;
        }

        public Task<ModuleAuthDataViewModel> Handle(RequestModuleAccessCommand request, CancellationToken cancellationToken)
        {
            // check chat and admin services

            var moduleData = ModuleAuthData.Create(
                request.RefreshToken,
                request.AccessToken,
                request.UserId,
                request.SessionId,
                request.ModuleName);

            _moduleAuthRepository.SetAuthModuleData(moduleData);
            
            var viewModel = _mapper.Map<ModuleAuthDataViewModel>(moduleData);
            return Task.FromResult(viewModel);
        }
    }
}
