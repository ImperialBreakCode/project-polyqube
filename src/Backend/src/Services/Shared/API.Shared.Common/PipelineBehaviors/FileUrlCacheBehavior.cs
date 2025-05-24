using API.Shared.Common.FileUrlTransform;
using MediatR;

namespace API.Shared.Common.PipelineBehaviors
{
    public class FileUrlCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class, IIncludeFileUrl
        where TRequest : notnull
    {
        private readonly IServiceProvider _serviceProvider;

        public FileUrlCacheBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            var transformer = (IFileUrlTransformer<TResponse>?)_serviceProvider.GetService(typeof(IFileUrlTransformer<TResponse>));
            if (transformer is null)
            {
                throw new InvalidOperationException();
            }

            await transformer.TransformUrl(response);

            return response;
        }
    }
}
