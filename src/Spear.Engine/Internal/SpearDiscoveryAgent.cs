using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;

namespace Spear.Engine.Internal
{
    internal class SpearDiscoveryAgent : ISpearDiscoveryAgent, IDisposable
    {
        private bool _disposedValue;
        private readonly ISpearPersister _spearPersistancy;

        public SpearDiscoveryAgent(ISpearPersister spearPersistancy)
        {
            _spearPersistancy = spearPersistancy
                ?? throw new ArgumentNullException(nameof(spearPersistancy));
        }

        public IEnumerable<ServiceCatalogDefinition> DiscoverAllServices()
        {
            return _spearPersistancy.GetAll();
        }

        public IEnumerable<ServiceCatalogDefinition> DiscoverAllServices(DataPlane dataPlane)
        {
            return _spearPersistancy.GetAll(dataPlane);
        }

        public IEnumerable<ServiceCatalogDefinition> DiscoverAllServices(string serviceCatalogName)
        {
            return _spearPersistancy.GetAll(serviceCatalogName);
        }

        public ServiceCatalogDefinition? DiscoverService(string serviceCatalogName, DataPlane dataPlane)
        {
            return _spearPersistancy.Get(serviceCatalogName, dataPlane);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _spearPersistancy.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
