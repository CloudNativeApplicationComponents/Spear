using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public class ServerEventMethodDefinition : ServerMethodDefinitionBase
    {
        public ServerEventMethodDefinition(string name) : base(name)
        {
        }

        public override SpearServiceMethodType MethodType => SpearServiceMethodType.Event;

        public override void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context)
        {
            _ = visitor
                ?? throw new ArgumentNullException(nameof(visitor));

            visitor.Visit(this, context);
        }
    }
}
