using System.Collections.Generic;

namespace Spear.Api.Application.ServiceCatalogs
{
    internal class ServiceCatalogDefinitionConfiguration
    {
        public string Name { get; set; } = string.Empty;
        public string DataPlane { get; set; } = string.Empty;
        public IList<ServiceDefinitionConfiguration> Services { get; set; } = new List<ServiceDefinitionConfiguration>();

        public record ServiceDefinitionConfiguration
        {
            public string Name { get; set; } = string.Empty;
            public string MethodType { get; set; } = string.Empty;
        }
    }
}