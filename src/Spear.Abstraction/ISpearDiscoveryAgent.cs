using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface ISpearDiscoveryAgent : IDisposable
    {
        IEnumerable<ServiceCatalogDefinition> DiscoverAllServices();
    }
}
