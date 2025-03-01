using MediatR;

namespace API.Shared.Application.Interfaces
{
    public interface IQueryHandler<TQuery, TReponse> : IRequestHandler<TQuery, TReponse>
        where TQuery : IQuery<TReponse>;
}
