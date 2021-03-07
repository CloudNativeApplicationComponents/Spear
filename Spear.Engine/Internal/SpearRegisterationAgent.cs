using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using System;

namespace Spear.Engine.Internal
{
    internal class SpearRegisterationAgent : ISpearRegisterationAgent, IDisposable
    {
        private bool disposedValue;
        private ISpearPersister _spearPersistancy;

        public SpearRegisterationAgent(ISpearPersister spearPersistancy)
        {
            _spearPersistancy = spearPersistancy
                ?? throw new ArgumentNullException(nameof(spearPersistancy));
        }

        public void Register(ServiceCatalogDefinition serviceDefinition)
        {
            _spearPersistancy.Merge(serviceDefinition);
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
