using MediatR;

namespace API.Shared.Application.Interfaces
{
    public interface IQuery<TResult> : IRequest<TResult>;
}
