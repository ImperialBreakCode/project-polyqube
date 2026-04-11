using API.Admin.Domain;
using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.FeatureInfos.Requests;
using MassTransit;

namespace API.Admin.Application.Features.FeatureInfos.Consumers
{
    public class CheckFeatureUserAccessConsumer : IConsumer<CheckFeatureUserAccess>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckFeatureUserAccessConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CheckFeatureUserAccess> context)
        {
            string userId = context.Message.UserId;
            var feature = await _unitOfWork.FeatureInfoRepository
                .GetByFeatureNameAsync(context.Message.FeatureName);

            if (feature is null)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
                return;
            }

            if (feature.Mode == FeatureMode.Off)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
                return;
            }

            if (feature.Mode == FeatureMode.Test
                && !await _unitOfWork.FeatureInfoRepository.CheckIfUserIsTestUserAsync(feature.Id, userId))
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
                return;
            }

            if (feature.UserRestrictionsEnabled
                && !await _unitOfWork.FeatureInfoRepository.CheckIfUserIsTestUserAsync(feature.Id, userId))
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
                return;
            }

            await context.RespondAsync(BasicOperationResult.SuccessResult);
        }
    }
}
