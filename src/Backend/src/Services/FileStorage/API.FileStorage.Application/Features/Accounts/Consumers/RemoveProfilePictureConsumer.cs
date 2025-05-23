using API.FileStorage.Common.Constants;
using API.FileStorage.Domain.Factories;
using API.Shared.Application.Contracts.Base;
using API.Shared.Application.Contracts.FileStorage.Requests;
using MassTransit;

namespace API.FileStorage.Application.Features.Accounts.Consumers
{
    public class RemoveProfilePictureConsumer : IConsumer<RemoveProfilePictureRequest>
    {
        private readonly IDomainServiceFactory _domainServiceFactory;

        public RemoveProfilePictureConsumer(IDomainServiceFactory domainServiceFactory)
        {
            _domainServiceFactory = domainServiceFactory;
        }

        public async Task Consume(ConsumeContext<RemoveProfilePictureRequest> context)
        {
            var fileService = _domainServiceFactory.CreateFileService();

            try
            {
                await fileService.DeleteFile(context.Message.FilePath, MinioConstants.AccountsBucketName);
                await context.RespondAsync(BasicOperationResult.SuccessResult);
            }
            catch (Exception)
            {
                await context.RespondAsync(BasicOperationResult.FailResult);
            }
        }
    }
}
