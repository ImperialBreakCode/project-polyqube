using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.Chats.Requests;
using API.Shared.Application.Contracts.FeatureInfos.Requests;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions.Chats;
using API.Shared.Common.Exceptions.FeatureInfos;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Commands.RequestModuleAccess
{
    internal class RequestModuleAccessCommandHandler : ICommandHandler<RequestModuleAccessCommand, ModuleAuthDataViewModel>
    {
        private readonly IModuleAuthDataRepository _moduleAuthRepository;
        private readonly IMapper _mapper;
        private readonly IRequestClient<CheckChatProfileExistsRequest> _chatRequestClient;
        private readonly IRequestClient<CheckFeatureUserAccessRequest> _featureUserAccessRequestClient;

        public RequestModuleAccessCommandHandler(
            IModuleAuthDataRepository moduleAuthRepository, 
            IMapper mapper, 
            IRequestClient<CheckChatProfileExistsRequest> chatRequestClient, 
            IRequestClient<CheckFeatureUserAccessRequest> featureUserAccessRequestClient)
        {
            _moduleAuthRepository = moduleAuthRepository;
            _mapper = mapper;
            _chatRequestClient = chatRequestClient;
            _featureUserAccessRequestClient = featureUserAccessRequestClient;
        }

        public async Task<ModuleAuthDataViewModel> Handle(RequestModuleAccessCommand request, CancellationToken cancellationToken)
        {
            var hasAccessResponse = await _featureUserAccessRequestClient
                .GetResponse<BasicOperationResult>(CheckFeatureUserAccessRequest.Create(request.UserId, request.ModuleName));
            if (!hasAccessResponse.Message.Success)
            {
                throw new NoUserFeatureAccessException();
            }

            var chatResponse = await _chatRequestClient
                .GetResponse<BasicOperationResult>(CheckChatProfileExistsRequest.Create(request.UserId));
            if (!chatResponse.Message.Success)
            {
                throw new ChatProfileNotFoundException();
            }

            var moduleData = ModuleAuthData.Create(
                request.RefreshToken,
                request.AccessToken,
                request.UserId,
                request.SessionId,
                request.ModuleName);

            _moduleAuthRepository.SetAuthModuleData(moduleData);
            
            return _mapper.Map<ModuleAuthDataViewModel>(moduleData);
        }
    }
}
