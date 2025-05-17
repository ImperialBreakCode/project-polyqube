using API.FileStorage.Common.Constants;
using API.FileStorage.Domain.Factories;
using API.FileStorage.Domain.Models;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Contracts.FileStorage.Results;
using MassTransit;

namespace API.FileStorage.Application.Features.Accounts.Consumers
{
    public class SaveProfilePictureConsumer : IConsumer<SaveProfilePictureRequest>
    {
        private readonly IDomainServiceFactory _domainServiceFactory;

        public SaveProfilePictureConsumer(IDomainServiceFactory domainServiceFactory)
        {
            _domainServiceFactory = domainServiceFactory;
        }

        public async Task Consume(ConsumeContext<SaveProfilePictureRequest> context)
        {
            var message = context.Message;
            var fileName = $"{Guid.NewGuid()}_{TimeSpan.FromMilliseconds}{Path.GetExtension(message.FileName)}";
            var filePath = Path.Combine(AccountsPathConstants.AccountPath, AccountsPathConstants.ProfilePictures, fileName);
            var fileService = _domainServiceFactory.CreateFileService();

            try
            {
                using (Stream stream = await message.Stream.Value)
                {
                    var fileObj = FileObj.Create(
                        filePath,
                        message.MimeType,
                        MinioConstants.AccountsBucketName,
                        stream);

                    await fileService.UploadFile(fileObj);
                }

                await context.RespondAsync(FileSaveResult.SuccessResult(filePath));
            }
            catch (Exception)
            {
                await context.RespondAsync(FileSaveResult.FailResult);
            }
        }
    }
}
