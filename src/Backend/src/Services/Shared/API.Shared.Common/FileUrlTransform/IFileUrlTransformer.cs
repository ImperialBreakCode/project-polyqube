namespace API.Shared.Common.FileUrlTransform
{
    public interface IFileUrlTransformer<T>
        where T : class
    {
        Task TransformUrl(T model);
    }
}
