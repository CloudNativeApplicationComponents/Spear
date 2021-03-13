using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spear.Client.Services
{
    public interface ISpearDiscoveryClient
    {
        Task<IEnumerable<ServiceCatalogDefinition>> GetServiceCatalogDefinition(
            ServiceCatalogDefinitionFilter filter = default);
    }
}
