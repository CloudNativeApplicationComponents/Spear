using Spear.Abstraction.Definitions;
using Spear.Api.Application.ServiceCatalogs;
using System.Linq;
using static Spear.Api.Application.ServiceCatalogs.ServiceCatalogDto;

namespace Spear.Api.Application
{
    internal static class TypeMapper
    {
        internal static ServiceCatalogDto ToServiceCatalogDto(ServiceCatalogDefinition serviceDefinition)
            => new ServiceCatalogDto(
                serviceDefinition.Name,
                serviceDefinition.DataPlane.ToString(),
                serviceDefinition.Services.Select(t => ToServiceDefinitionDto(t)).ToList());


        internal static ServiceDefinitionDto ToServiceDefinitionDto(ServiceDefinition serviceDefinition) 
            => new ServiceDefinitionDto(
                serviceDefinition.Name,
                serviceDefinition.MethodType.ToString());
    }
}
