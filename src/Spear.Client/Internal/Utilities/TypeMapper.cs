using Spear.Client.Internal.SpearHttpClient.Contract;
using Spear.Client.Services;
using System.Linq;

namespace Spear.Client.Internal.Utilities
{
    internal static class TypeMapper
    {
        public static ServiceCatalogDefinition ToServiceCatalogDefinition(ServiceCatalogDefinitionDto dto)
        {
            return new ServiceCatalogDefinition(
                dto.Name,
                dto.DataPlane,
                dto.Services.Select(t =>
                new ServiceCatalogDefinition.ServiceDefinition(t.Name, t.MethodType)).ToList());
        }

        public static ServiceCatalogDefinitionDto ToServiceCatalogDto(ServiceCatalogDefinition serviceCatalogDefinition)
        {
            return new ServiceCatalogDefinitionDto(
                serviceCatalogDefinition.Name,
                serviceCatalogDefinition.DataPlane,
                serviceCatalogDefinition.Services
                .Select(t => new ServiceCatalogDefinitionDto.ServiceDefinitionDto(t.Name, t.MethodType)).ToList());
        }
    }
}
