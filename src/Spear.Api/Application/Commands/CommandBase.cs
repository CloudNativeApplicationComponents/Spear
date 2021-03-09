using System;

namespace Spear.Api.Application.Commands
{
    public class CommandBase : ICommand
    {
        public Guid Id { get; }

        public CommandBase() : this(Guid.NewGuid())
        { }

        protected CommandBase(Guid id)
        {
            Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected CommandBase() : this(Guid.NewGuid())
        { }

        protected CommandBase(Guid id)
        {
            Id = id;
        }
    }
}
