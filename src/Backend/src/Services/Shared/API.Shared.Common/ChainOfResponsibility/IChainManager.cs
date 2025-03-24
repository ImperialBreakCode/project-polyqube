namespace API.Shared.Common.ChainOfResponsibility
{
    public interface IChainManager<T>
    {
        Task ExecuteChain(T data);
    }
}
