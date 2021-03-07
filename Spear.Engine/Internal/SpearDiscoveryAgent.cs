using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;

namespace Spear.Engine.Internal
{
    internal class SpearDiscoveryAgent : ISpearDiscoveryAgent, IDisposable
    {
        private bool disposedValue;
        private ISpearPersister _spearPersistancy;

        public SpearDiscoveryAgent(ISpearPersister spearPersistancy)
        {
            _spearPersistancy = spearPersistancy
                ?? throw new ArgumentNullException(nameof(spearPersistancy));
        }

        public IEnumerable<ServiceCatalogDefinition> DiscoverAllServices()
        {
            return _spearPersistancy.GetAll();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _spearPersistancy.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
