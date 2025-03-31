namespace API.Shared.Common.ChainOfResponsibility
{
    public abstract class ChainManager<T> : IChainManager<T>
    {
        private readonly ICollection<IChainHandler<T>> _handlers = [];

        public async Task ExecuteChain(T data)
        {
            await _handlers.First().Handle(data);
        }

        protected void AddHandler(IChainHandler<T> handler)
        {
            if (_handlers.Count != 0)
            {
                _handlers.Last().SetNext(handler);
            }

            _handlers.Add(handler);
        }
    }
}
