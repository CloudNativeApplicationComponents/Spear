using System.Threading.Tasks;

namespace Spear.Client.Services
{
    public interface ISpearRegistrationClient
    {
        Task<ServiceCatalogDefinition> RegisterServiceCatalogDefinition(ServiceCatalogDefinition serviceCatalog);
    }
}
