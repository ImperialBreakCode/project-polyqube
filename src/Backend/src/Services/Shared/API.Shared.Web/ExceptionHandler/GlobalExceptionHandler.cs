using API.Shared.Common.Exceptions.Base;
using API.Shared.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace API.Shared.Web.ExceptionHandler
{
    internal class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            if (exception is APIException apiException)
            {
                await HandleAPIExceptions(httpContext, apiException, cancellationToken);
            }
            else
            {
                await HandleUnknownException(httpContext, exception, cancellationToken);
            }

            return true;
        }

        private async Task HandleAPIExceptions(HttpContext httpContext, APIException exception, CancellationToken cancellationToken)
        {
            var statusCode = (int)exception.StatusCode;

            var problemDetails = new ProblemResponseDTO()
            {
                Title = Enum.GetName(exception.StatusCode)!,
                Type = exception.GetType().Name,
                DetailsMessage = exception.Message,
                StatusCode = statusCode,
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        private async Task HandleUnknownException(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemResponseDTO()
            {
                Title = "InternalServerError",
                Type = "UnknownException",
                DetailsMessage = "Unknown message",
                StatusCode = statusCode,
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }
    }
}
