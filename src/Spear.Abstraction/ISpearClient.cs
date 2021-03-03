using System;

namespace Spear.Abstraction
{
    public interface ISpearClient : IDisposable
    {
        ISpearDiscoveryClient Discovery();
        ISpearDiscoveryAgent Agent();
    }
}
