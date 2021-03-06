using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public class SpearServerDuplexStreamingMethodDefinition : ServerMethodDefinitionBase
    {
        public SpearServerDuplexStreamingMethodDefinition(string name) : base(name)
        {
        }

        public override SpearServiceMethodType MethodType => SpearServiceMethodType.DuplexStreaming;

        public override void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context)
        {
            _ = visitor
                ?? throw new ArgumentNullException(nameof(visitor));

            visitor.Visit(this, context);
        }
    }
}
