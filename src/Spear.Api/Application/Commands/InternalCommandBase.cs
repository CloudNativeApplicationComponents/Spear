using System;

namespace Spear.Api.Application.Commands
{
    internal abstract class InternalCommandBase : ICommand
    {
        public Guid Id { get; }

        protected InternalCommandBase(Guid id)
        {
            Id = id;
        }
    }

    internal abstract class InternalCommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected InternalCommandBase() : this(Guid.NewGuid())
        { }

        protected InternalCommandBase(Guid id)
        {
            Id = id;
        }
    }
}
