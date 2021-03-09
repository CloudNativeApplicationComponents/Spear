using MediatR;
using System;

namespace Spear.Api.Application.Commands
{
    internal interface ICommand : IRequest
    {
        Guid Id { get; }
    }

    internal interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}