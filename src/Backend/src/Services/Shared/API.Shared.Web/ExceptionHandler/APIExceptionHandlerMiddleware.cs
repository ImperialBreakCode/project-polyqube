using API.Shared.Common.Exceptions;
using API.Shared.Common.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.ExceptionHandler
{
    internal class APIExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public APIExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(UnprocessableContentException ex)
            {
                await HandleValidationErrorException(context, ex);
            }
            catch (APIException ex)
            {
                await HandleAPIExceptions(context, ex);
            }
            
        }

        private async Task HandleValidationErrorException(HttpContext httpContext, UnprocessableContentException exception)
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
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }

        private async Task HandleAPIExceptions(HttpContext httpContext, APIException exception)
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
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
