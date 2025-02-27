using MediatR;

namespace API.Shared.Application.Interfaces
{
    internal interface IQueryHandler<TQuery, TReponse> : IRequestHandler<TQuery, TReponse>
        where TQuery : IQuery<TReponse>;
}
