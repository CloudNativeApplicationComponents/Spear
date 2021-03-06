using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public class SpearServerServerStreamingMethodDefinition : ServerMethodDefinitionBase
    {
        public SpearServerServerStreamingMethodDefinition(string name) : base(name)
        {
        }

        public override SpearServiceMethodType MethodType => SpearServiceMethodType.ServerStreaming;

        public override void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context)
        {
            _ = visitor
                ?? throw new ArgumentNullException(nameof(visitor));

            visitor.Visit(this, context);
        }
    }
}
