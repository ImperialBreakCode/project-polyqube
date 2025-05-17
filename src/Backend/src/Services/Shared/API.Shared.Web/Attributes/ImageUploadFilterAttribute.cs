using API.Shared.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Shared.Web.Attributes
{
    public class ImageUploadFilterAttribute : ActionFilterAttribute
    {
        private readonly string[] _allowedMimeTypes = ["image/jpeg", "image/png"];
        private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".png"];

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;

            if (!request.HasFormContentType)
            {
                throw new BadRequestException("Request must be of type multipart/form-data.");
            }

            var form = await request.ReadFormAsync();
            var file = form.Files.FirstOrDefault(f => f.Name == "FormFile");

            if (!_allowedMimeTypes.Contains(file.ContentType))
            {
                throw new BadRequestException("Invalid file type.");
            }

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(ext))
            {
                throw new BadRequestException("Invalid file extension.");
            }
        }
    }
}
