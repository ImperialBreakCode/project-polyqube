namespace API.Shared.Common.ChainOfResponsibility
{
    public abstract class ChainHandler<T> : IChainHandler<T>
    {
        private IChainHandler<T>? _nextHandler;

        public async Task Handle(T data)
        {
            await Execute(data);

            if (_nextHandler is not null)
            {
                await _nextHandler.Handle(data);
            }
        }

        public void SetNext(IChainHandler<T> chainHandler)
        {
            _nextHandler = chainHandler;
        }

        protected abstract Task Execute(T data);
    }
}
