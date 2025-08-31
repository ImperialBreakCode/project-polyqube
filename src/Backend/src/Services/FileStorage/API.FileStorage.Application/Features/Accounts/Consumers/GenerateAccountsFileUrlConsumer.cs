using API.FileStorage.Application.Helpers;
using API.FileStorage.Common.Constants;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Contracts.FileStorage.Results;
using MassTransit;

namespace API.FileStorage.Application.Features.Accounts.Consumers
{
    public class GenerateAccountsFileUrlConsumer : IConsumer<GenerateAccountsFileUrlRequest>
    {
        private readonly IObjectUrlGenerator _objectUrlGenerator;

        public GenerateAccountsFileUrlConsumer(IObjectUrlGenerator objectUrlGenerator)
        {
            _objectUrlGenerator = objectUrlGenerator;
        }

        public async Task Consume(ConsumeContext<GenerateAccountsFileUrlRequest> context)
        {
            try
            {
                var path = await _objectUrlGenerator
                    .GenerateObjectUrl(context.Message.FilePath, MinioConstants.AccountsBucketName);

                await context.RespondAsync(FilePathResult.SuccessResult(path));
            }
            catch (Exception)
            {
                await context.RespondAsync(FilePathResult.FailResult);
            }
        }
    }
}
