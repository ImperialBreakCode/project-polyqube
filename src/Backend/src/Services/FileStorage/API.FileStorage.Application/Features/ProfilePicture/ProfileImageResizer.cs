using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace API.FileStorage.Application.Features.ProfilePicture
{
    internal class ProfileImageResizer : IProfileImageResizer
    {
        private const int SIDE_SIZE = 480;


        public void CropAndResize(Stream inputStream, Stream outputStream)
        {
            using var image = Image.Load(inputStream);

            var cropLength = Math.Min(image.Width, image.Height);

            int x = (image.Width - cropLength) / 2;
            int y = (image.Height - cropLength) / 2;

            var cropRect = new Rectangle(x, y, cropLength, cropLength);

            image.Mutate(ctx => ctx
                .Crop(cropRect)
                .Resize(SIDE_SIZE, SIDE_SIZE));

            image.SaveAsJpeg(outputStream);

            outputStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
