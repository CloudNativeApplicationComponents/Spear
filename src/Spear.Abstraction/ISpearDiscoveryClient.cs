using System;
using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface ISpearDiscoveryClient : IDisposable
    {
        IEnumerable<ISpearServiceDefinition> DiscoverAllServices();
    }
}
