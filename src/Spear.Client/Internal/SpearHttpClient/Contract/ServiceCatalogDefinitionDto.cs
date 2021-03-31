using System.Collections.Generic;

namespace Spear.Client.Internal.SpearHttpClient.Contract
{
    internal class ServiceCatalogDefinitionDto
    {
        public string Name { get; set; }
        public string DataPlane { get; set; }

        public IList<ServiceDefinitionDto> Services { get; set; }

        public ServiceCatalogDefinitionDto(string name, string dataplane, IList<ServiceDefinitionDto> services)
        {
            Name = name;
            DataPlane = dataplane;
            Services = services;
        }

        public class ServiceDefinitionDto
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
