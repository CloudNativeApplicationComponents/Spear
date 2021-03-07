using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface ISpearDiscoveryAgent : IDisposable
    {
        IEnumerable<ServiceCatalogDefinition> DiscoverAllServices();
        IEnumerable<ServiceCatalogDefinition> DiscoverAllServices(DataPlane dataPlane);
        IEnumerable<ServiceCatalogDefinition> DiscoverAllServices(string serviceCatalogName);
        ServiceCatalogDefinition? DiscoverService(string serviceCatalogName, DataPlane dataPlane);
    }
}
