using System.Collections.Generic;

namespace Spear.Api.Application.ServiceCatalogs
{
    public record ServiceCatalogDto
    {
        public string Name { get; set; }
        public string DataPlane { get; set; }
        public IList<ServiceDefinitionDto> Services { get; set; }

        public ServiceCatalogDto(string name, string dataPlane, IList<ServiceDefinitionDto> services)
        {
            Name = name;
            DataPlane = dataPlane;
            Services = services;
        }

        public record ServiceDefinitionDto
        {
            public string Name { get; set; }
            public string MethodType { get; set; }

            public ServiceDefinitionDto(string name, string methodType)
            {
                Name = name;
                MethodType = methodType;
            }
        }
    }
}
