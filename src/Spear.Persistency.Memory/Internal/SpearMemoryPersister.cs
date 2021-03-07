using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Spear.Persistency.Memory.Internal
{
    internal class SpearMemoryPersister : ISpearPersister
    {
        public void Merge(ServiceCatalogDefinition serviceCatalogDefinition)
        {
            _ = serviceCatalogDefinition ??
                throw new ArgumentNullException(nameof(serviceCatalogDefinition));

            var key = (serviceCatalogDefinition.Name, serviceCatalogDefinition.DataPlane);

            if (ServiceDefinitionCache.ServiceDefinitions.TryGetValue(key, out var existsValue))
            {
                foreach (var service in serviceCatalogDefinition.Services)
                {
                    if (!existsValue.Services.Contains(service))
                        existsValue.Services.Add(service);
                }
            }
            else
            {
                ServiceDefinitionCache.ServiceDefinitions.Add(key, serviceCatalogDefinition);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(false);
        }

        public IEnumerable<ServiceCatalogDefinition> GetAll()
        {
            var items = ServiceDefinitionCache.ServiceDefinitions.Values.ToList();
            return new ReadOnlyCollection<ServiceCatalogDefinition>(items);
        }

        public IEnumerable<ServiceCatalogDefinition> GetAll(DataPlane dataPlane)
        {
            return GetAll().Where(t => t.DataPlane == dataPlane);
        }

        public IEnumerable<ServiceCatalogDefinition> GetAll(string serviceCatalogName)
        {
            return GetAll().Where(t => string.Equals(t.Name, serviceCatalogName, StringComparison.InvariantCulture));
        }

        public ServiceCatalogDefinition Get(string serviceCatalogName, DataPlane dataPlane)
        {
            return GetAll(serviceCatalogName).FirstOrDefault(t => t.DataPlane == dataPlane);
        }

        private class ServiceDefinitionCache
        {
            public static IDictionary<(string, DataPlane), ServiceCatalogDefinition> ServiceDefinitions { get; }

            static ServiceDefinitionCache()
            {
                ServiceDefinitions = new Dictionary<(string, DataPlane), ServiceCatalogDefinition>();
            }
        }
    }
}
