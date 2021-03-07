using MediatR;

namespace Spear.Api.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    { }
}
