using MediatR;

namespace Spear.Api.Application.Queries
{
    internal interface IQuery<out TResult> : IRequest<TResult>
    { }
}
