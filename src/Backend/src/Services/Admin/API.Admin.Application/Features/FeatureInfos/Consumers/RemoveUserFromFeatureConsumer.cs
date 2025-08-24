using API.Admin.Domain;
using API.Shared.Application.Contracts.FeatureInfos.Commands;
using API.Shared.Application.Contracts.FeatureInfos.Events;
using MassTransit;

namespace API.Admin.Application.Features.FeatureInfos.Consumers
{
    public class RemoveUserFromFeatureConsumer : IConsumer<RemoveUserFromFeatureInfos>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserFromFeatureConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<RemoveUserFromFeatureInfos> context)
        {
            await _unitOfWork.FeatureInfoRepository.ExecuteUserIdsRemoval(context.Message.UserId);

            await context.Publish<UserRemovedFromFeatureInfosEvent>(new(context.Message.UserId));
        }
    }
}
