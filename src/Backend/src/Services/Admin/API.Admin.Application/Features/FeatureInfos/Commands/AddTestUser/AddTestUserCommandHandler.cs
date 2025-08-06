using API.Admin.Common.Features.FeatureInfo.Exceptions;
using API.Admin.Domain;
using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions.Accounts;
using MassTransit;

namespace API.Admin.Application.Features.FeatureInfos.Commands.AddTestUser
{
    internal class AddTestUserCommandHandler : ICommandHandler<AddTestUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestClient<CheckIfUserIdExistsRequest> _requestClient;

        public AddTestUserCommandHandler(IUnitOfWork unitOfWork, IRequestClient<CheckIfUserIdExistsRequest> requestClient)
        {
            _unitOfWork = unitOfWork;
            _requestClient = requestClient;
        }

        public async Task Handle(AddTestUserCommand request, CancellationToken cancellationToken)
        {
            var feature = _unitOfWork.FeatureInfoRepository.GetById(request.FeatureId);
            if (feature is null)
            {
                throw new FeatureNotFoundException();
            }

            var userCheckResult = await _requestClient
                .GetResponse<BasicOperationResult>(CheckIfUserIdExistsRequest.Create(request.UserId));

            if (!userCheckResult.Message.Success)
            {
                throw new AccountNotFoundException();
            }

            await _unitOfWork.FeatureInfoRepository.AddTestUserAsync(TestUser.Create(request.UserId, request.FeatureId));
            _unitOfWork.Save();
        }
    }
}
