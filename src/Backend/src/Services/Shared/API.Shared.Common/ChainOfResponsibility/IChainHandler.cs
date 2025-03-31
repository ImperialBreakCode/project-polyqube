namespace API.Shared.Common.ChainOfResponsibility
{
    public interface IChainHandler<T>
    {
        void SetNext(IChainHandler<T> chainHandler);
        Task Handle(T data);
    }
}
