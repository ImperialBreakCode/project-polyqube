using API.Shared.Common.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            var problemDetails = new ValidationProblemDetails()
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
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ValidationProblemDetails()
            {
                Title = "InternalServerError",
                Type = "UnknownException",
                Detail = "Unknown message",
                Status = statusCode,
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }
    }
}
