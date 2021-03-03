using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface IServiceDefinition
    {
        string Name { get; }
        IEnumerable<IMethodDefinition> Methods { get; }
    }
}
