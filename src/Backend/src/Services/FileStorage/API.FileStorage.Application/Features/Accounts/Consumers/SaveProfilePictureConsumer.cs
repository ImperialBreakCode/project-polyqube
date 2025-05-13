using API.FileStorage.Common.Constants;
using API.FileStorage.Domain.Factories;
using API.FileStorage.Domain.Models;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Contracts.FileStorage.Results;
using MassTransit;

namespace API.FileStorage.Application.Features.Accounts.Consumers
{
    internal class SaveProfilePictureConsumer : IConsumer<SaveProfilePictureRequest>
    {
        private readonly IDomainServiceFactory _domainServiceFactory;

        public SaveProfilePictureConsumer(IDomainServiceFactory domainServiceFactory)
        {
            _domainServiceFactory = domainServiceFactory;
        }

        public async Task Consume(ConsumeContext<SaveProfilePictureRequest> context)
        {
            var message = context.Message;
            var fileName = $"{Guid.NewGuid():hex}_{Path.GetExtension(message.FileName)}";
            var filePath = Path.Combine(AccountsPathConstants.AccountPath, AccountsPathConstants.ProfilePictures, fileName);

            try
            {
                var fileObj = FileObj.Create(
                fileName,
                filePath,
                message.MimeType,
                MinioConstants.AccountsBucketName,
                await message.ByteContent.Value);

                var fileService = _domainServiceFactory.CreateFileService();

                await fileService.UploadFile(fileObj);

                await context.RespondAsync(FileOperationResult.SuccessResult);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(FileOperationResult.FailResult(ex.Message));
            }
            
        }
    }
}
