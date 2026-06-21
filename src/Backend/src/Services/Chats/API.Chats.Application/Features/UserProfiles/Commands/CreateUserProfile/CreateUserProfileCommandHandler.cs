using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Results;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.FeatureInfos.Requests;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Constants;
using API.Shared.Common.Exceptions.Accounts;
using API.Shared.Common.Exceptions.FeatureInfos;
using AutoMapper;
using MassTransit;

namespace API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    internal class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, UserProfileViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRequestClient<CheckFeatureUserAccessRequest> _featureAccessRequestClient;
        private readonly IRequestClient<GetUserDetailsByUserIdRequest> _getUserDetailsRequestClient;

        public CreateUserProfileCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRequestClient<CheckFeatureUserAccessRequest> requestClient,
            IRequestClient<GetUserDetailsByUserIdRequest> getUserDetailsRequestClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _featureAccessRequestClient = requestClient;
            _getUserDetailsRequestClient = getUserDetailsRequestClient;
        }

        public async Task<UserProfileViewModel> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var hasAccessRequest = CheckFeatureUserAccessRequest.Create(request.UserId, FeatureInfoNames.CHAT_SERVICE);
            var hasAccessResult = await _featureAccessRequestClient.GetResponse<BasicOperationResult>(hasAccessRequest, cancellationToken);
            if (!hasAccessResult.Message.Success)
            {
                throw new NoFeatureAccessException();
            }

            var getDetailsRequest = GetUserDetailsByUserIdRequest.Create(request.UserId);
            var userDetailsResult = await _getUserDetailsRequestClient.GetResponse<UserDetailsResult>(getDetailsRequest, cancellationToken);
            if (userDetailsResult.Message.UserDetailsResultData is null)
            {
                throw new AccountDetailsNotFoundException();
            }

            var userDetails = userDetailsResult.Message.UserDetailsResultData;

            var userProfile = UserProfile.Create(request.UserId);
            userProfile.FirstName = userDetails.FirstName;
            userProfile.LastName = userDetails.LastName;
            userProfile.ProfilePicture = userDetails.ProfilePicturePath;

            _unitOfWork.UserProfileRepository.Insert(userProfile);
            _unitOfWork.Save();

            return _mapper.Map<UserProfileViewModel>(userProfile);
        }
    }
}
