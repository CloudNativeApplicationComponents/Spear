using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public abstract class ServerMethodDefinitionBase : ISpearServerMethodDefinition
    {
        public string Name { get; }

        public ServerMethodDefinitionBase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);
            Name = name;
        }

        public abstract SpearServiceMethodType MethodType { get; }

        public abstract void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context);
    }
}
