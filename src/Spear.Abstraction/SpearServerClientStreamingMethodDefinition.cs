using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public class SpearServerClientStreamingMethodDefinition : ServerMethodDefinitionBase
    {
        public SpearServerClientStreamingMethodDefinition(string name) : base(name)
        {
        }

        public override SpearServiceMethodType MethodType => SpearServiceMethodType.ClientStreaming;

        public override void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context)
        {
            _ = visitor
                ?? throw new ArgumentNullException(nameof(visitor));

            visitor.Visit(this, context);
        }
    }
}
