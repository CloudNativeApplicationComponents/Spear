using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;

namespace Spear.Abstraction
{
    public interface ISpearPersister : IDisposable
    {
        IEnumerable<ServiceCatalogDefinition> GetAll();
        IEnumerable<ServiceCatalogDefinition> GetAll(DataPlane dataPlane);
        IEnumerable<ServiceCatalogDefinition> GetAll(string serviceCatalogName);
        ServiceCatalogDefinition? Get(string serviceCatalogName, DataPlane dataPlane);
        void Merge(ServiceCatalogDefinition serviceCatalogDefinition);
    }
}
