using API.Shared.Web.ExceptionHandler;
using Microsoft.AspNetCore.Builder;

namespace API.Shared.Web.Extensions
{
    public static class MiddlewareConfig
    {
        public static void UseExceptionHandlers(this WebApplication app)
        {
            app.UseExceptionHandler();

            app.UseMiddleware<APIExceptionHandlerMiddleware>();
        }
    }
}
