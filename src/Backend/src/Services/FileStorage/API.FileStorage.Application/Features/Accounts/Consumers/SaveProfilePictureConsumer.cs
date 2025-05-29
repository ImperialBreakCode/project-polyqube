using API.FileStorage.Application.Features.ProfilePicture;
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
        private readonly IProfileImageResizer _profileImageResizer;

        public SaveProfilePictureConsumer(IDomainServiceFactory domainServiceFactory, IProfileImageResizer profileImageResizer)
        {
            _domainServiceFactory = domainServiceFactory;
            _profileImageResizer = profileImageResizer;
        }

        public async Task Consume(ConsumeContext<SaveProfilePictureRequest> context)
        {
            var message = context.Message;
            var fileName = $"{Guid.NewGuid()}_{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}.jpg";
            var filePath = Path.Combine(AccountsPathConstants.AccountPath, AccountsPathConstants.ProfilePictures, fileName);
            var fileService = _domainServiceFactory.CreateFileService();

            try
            {
                using (Stream stream = await message.Stream.Value)
                using (Stream outputStream = new MemoryStream())
                {
                    _profileImageResizer.CropAndResize(stream, outputStream);

                    var fileObj = FileObj.Create(
                        filePath,
                        "image/jpeg",
                        MinioConstants.AccountsBucketName,
                        outputStream);

                    await fileService.UploadFile(fileObj);
                }

                await context.RespondAsync(FilePathResult.SuccessResult(filePath));
            }
            catch (Exception)
            {
                await context.RespondAsync(FilePathResult.FailResult);
            }
        }
    }
}
