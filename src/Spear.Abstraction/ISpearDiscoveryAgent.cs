using System;

namespace Spear.Abstraction
{
    public interface ISpearDiscoveryAgent : IDisposable
    {
        void Register(ISpearServiceDefinition serviceDefinition);
    }
}
