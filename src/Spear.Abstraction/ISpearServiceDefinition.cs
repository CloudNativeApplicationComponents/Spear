using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface ISpearServiceDefinition
    {
        string Name { get; }

        IEnumerable<ISpearServerMethodDefinition> Methods { get; }
        DataPlane DataPlane { get; }
    }
}
