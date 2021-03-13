using System.Collections.Generic;

namespace Spear.Client.Services
{
    public class ServiceCatalogDefinition
    {
        public string Name { get; set; }
        public string DataPlane { get; set; }
        public IList<ServiceDefinition> Services { get; set; }

        public ServiceCatalogDefinition(string name, string dataPlane, IList<ServiceDefinition> services)
        {
            Name = name;
            DataPlane = dataPlane;
            Services = services;
        }

        public class ServiceDefinition
        {
            public string Name { get; set; }
            public string MethodType { get; set; }

            public ServiceDefinition(string name, string methodType)
            {
                Name = name;
                MethodType = methodType;
            }
        }
    }
}
