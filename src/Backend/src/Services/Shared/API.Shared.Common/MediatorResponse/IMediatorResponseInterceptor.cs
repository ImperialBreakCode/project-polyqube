namespace API.Shared.Common.MediatorResponse
{
    public interface IMediatorResponseInterceptor<T>
        where T : class
    {
        Task InterceptAndProcessResponse(T model);
    }
}
