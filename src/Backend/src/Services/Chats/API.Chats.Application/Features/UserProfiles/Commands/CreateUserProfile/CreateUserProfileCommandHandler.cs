using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.FeatureInfos.Requests;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Constants;
using API.Shared.Common.Exceptions.FeatureInfos;
using AutoMapper;
using MassTransit;

namespace API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    internal class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, UserProfileViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRequestClient<CheckFeatureUserAccessRequest> _requestClient;

        public CreateUserProfileCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IRequestClient<CheckFeatureUserAccessRequest> requestClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _requestClient = requestClient;
        }

        public async Task<UserProfileViewModel> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var rabbitRequest = CheckFeatureUserAccessRequest.Create(request.UserId, FeatureInfoNames.CHAT_SERVICE);
            var result = await _requestClient.GetResponse<BasicOperationResult>(rabbitRequest, cancellationToken);

            if (!result.Message.Success)
            {
                throw new NoUserFeatureAccessException();
            }

            var userProfile = UserProfile.Create(request.UserId);
            _unitOfWork.UserProfileRepository.Insert(userProfile);
            _unitOfWork.Save();

            return _mapper.Map<UserProfileViewModel>(userProfile);
        }
    }
}
