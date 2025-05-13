using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Shared.Web.Attributes
{
    public class ImageUploadFilterAttribute : ActionFilterAttribute
    {
        private readonly string[] _allowedMimeTypes = ["image/jpeg", "image/png"];
        private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".png"];

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("formFile", out var fileObj) || fileObj is not IFormFile file)
            {
                context.Result = new BadRequestObjectResult("File is missing.");
                return;
            }

            if (!_allowedMimeTypes.Contains(file.ContentType))
            {
                context.Result = new BadRequestObjectResult("Invalid file type.");
                return;
            }

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(ext))
            {
                context.Result = new BadRequestObjectResult("Invalid file extension.");
                return;
            }
        }
    }
}
