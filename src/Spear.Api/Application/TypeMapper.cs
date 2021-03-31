using Spear.Abstraction.Definitions;
using Spear.Api.Application.ServiceCatalogs;
using System.Linq;
using static Spear.Api.Application.ServiceCatalogs.ServiceCatalogDefinitionConfiguration;
using static Spear.Api.Application.ServiceCatalogs.ServiceCatalogDefinitionDto;

namespace Spear.Api.Application
{
    internal static class TypeMapper
    {
        internal static ServiceCatalogDefinitionDto ToServiceCatalogDto(ServiceCatalogDefinition serviceDefinition)
            => new(
                serviceDefinition.Name,
                serviceDefinition.DataPlane.ToString(),
                serviceDefinition.Services.Select(t => ToServiceDefinitionDto(t)).ToList());

        internal static ServiceDefinitionDto ToServiceDefinitionDto(ServiceDefinition serviceDefinition)
            => new(
                serviceDefinition.Name,
                serviceDefinition.MethodType.ToString());

        internal static ServiceDefinitionDto ToServiceDefinitionDto(ServiceDefinitionConfiguration serviceDefinition)
            => new(
                serviceDefinition.Name,
                serviceDefinition.MethodType.ToString());
    }
}
