using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Shared.Common.PipelineBehaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<IPipelineBehavior<TRequest, TRequest>> _logger;

        public LoggingBehavior(ILogger<IPipelineBehavior<TRequest, TRequest>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Proccessing application request - {request}", requestName);

            return await next();
        }
    }
}
