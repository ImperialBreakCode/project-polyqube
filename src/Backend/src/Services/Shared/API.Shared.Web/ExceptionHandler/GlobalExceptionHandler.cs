using API.Shared.Common.Exceptions;
using API.Shared.Common.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.ExceptionHandler
{
    internal class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            if (exception is UnprocessableContentException unprocessableException)
            {
                await HandleValidationErrorException(httpContext, unprocessableException, cancellationToken);
            }
            else if (exception is APIException apiException)
            {
                await HandleAPIExceptions(httpContext, apiException, cancellationToken);
            }
            else
            {
                await HandleUnknownException(httpContext, exception, cancellationToken);
            }

            return true;
        }

        private async Task HandleValidationErrorException(HttpContext httpContext, UnprocessableContentException exception, CancellationToken cancellationToken)
        {
            var statusCode = (int)exception.StatusCode;

            var problemDetails = new ValidationProblemDetails()
            {
                Title = "Validation Errors",
                Detail = exception.Message,
                Type = exception.GetType().Name,
                Status = statusCode,
                Errors = exception.Errors
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        private async Task HandleAPIExceptions(HttpContext httpContext, APIException exception, CancellationToken cancellationToken)
        {
            var statusCode = (int)exception.StatusCode;

            var problemDetails = new ProblemDetails()
            {
                Title = Enum.GetName(exception.StatusCode)!,
                Type = exception.GetType().Name,
                Detail = exception.Message,
                Status = statusCode,
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        private async Task HandleUnknownException(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails()
            {
                Title = "InternalServerError",
                Type = "UnknownException",
                Detail = exception.Message,
                Status = statusCode,
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }
    }
}
