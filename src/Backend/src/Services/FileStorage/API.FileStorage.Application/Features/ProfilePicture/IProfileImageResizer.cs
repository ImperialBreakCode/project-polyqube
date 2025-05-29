namespace API.FileStorage.Application.Features.ProfilePicture
{
    public interface IProfileImageResizer
    {
        void CropAndResize(Stream inputStream, Stream outputStream);
    }
}
