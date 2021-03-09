using Spear.Client.Internal.SpearHttpClient.Contract;
using Spear.Client.Services;
using System.Linq;

namespace Spear.Client.Internal.Utilities
{
    internal static class TypeMapper
    {
        public static ServiceCatalogDefinition ToServiceCatalogDefinition(ServiceCatalogDto dto)
        {
            return new ServiceCatalogDefinition(
                dto.Name,
                dto.DataPlane,
                dto.Services.Select(t =>
                new ServiceCatalogDefinition.ServiceDefinition(t.Name, t.MethodType)).ToList());
        }

        public static ServiceCatalogDto ToServiceCatalogDto(ServiceCatalogDefinition serviceCatalogDefinition)
        {
            return new ServiceCatalogDto(
                serviceCatalogDefinition.Name,
                serviceCatalogDefinition.DataPlane,
                serviceCatalogDefinition.Services
                .Select(t => new ServiceCatalogDto.ServiceDefinitionDto(t.Name, t.MethodType)).ToList());
        }
    }
}
