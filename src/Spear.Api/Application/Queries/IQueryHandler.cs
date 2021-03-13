using MediatR;

namespace Spear.Api.Application.Queries
{
    internal interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}
