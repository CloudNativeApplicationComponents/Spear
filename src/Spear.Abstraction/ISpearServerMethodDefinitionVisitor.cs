using CloudNativeApplicationComponents.Utils;

namespace Spear.Abstraction
{
    public interface ISpearServerMethodDefinitionVisitor
    {
        void Visit(ServerEventMethodDefinition definition, AggregationContext context);
        void Visit(SpearServerUnaryMethodDefinition definition, AggregationContext context);
        void Visit(SpearServerClientStreamingMethodDefinition definition, AggregationContext context);
        void Visit(SpearServerServerStreamingMethodDefinition definition, AggregationContext context);
        void Visit(SpearServerDuplexStreamingMethodDefinition definition, AggregationContext context);
    }
}
