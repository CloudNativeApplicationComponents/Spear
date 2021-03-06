using CloudNativeApplicationComponents.Utils;

namespace Spear.Abstraction
{
    public interface ISpearServerMethodDefinition
    {
        string Name { get; }
        SpearServiceMethodType MethodType { get; }
        void Accept(ISpearServerMethodDefinitionVisitor visitor, AggregationContext context);
    }
}
