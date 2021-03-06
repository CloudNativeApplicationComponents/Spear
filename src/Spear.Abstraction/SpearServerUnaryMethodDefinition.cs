using CloudNativeApplicationComponents.Utils;
using System;

namespace Spear.Abstraction
{
    public class SpearServerUnaryMethodDefinition : ServerMethodDefinitionBase
    {
        public SpearServerUnaryMethodDefinition(string name) : base(name)
        {
        }

        public override SpearServiceMethodType MethodType => SpearServiceMethodType.Unary;

        public override void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context)
        {
            _ = visitor
                ?? throw new ArgumentNullException(nameof(visitor));

            visitor.Visit(this, context);
        }
    }
}
