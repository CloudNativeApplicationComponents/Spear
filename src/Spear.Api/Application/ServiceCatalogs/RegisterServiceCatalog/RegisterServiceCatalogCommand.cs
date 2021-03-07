using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.Commands;
using System.Collections.Generic;

namespace Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition
{
    public class RegisterServiceCatalogCommand : CommandBase<ServiceCatalogDto>
    {
        //Could be more abstract
        public string Name { get; set; }
        public DataPlane DataPlane { get; set; }
        public IList<ServiceDefinitionDto> Services { get; set; }

        public record ServiceDefinitionDto
        {
            public string Name { get; set; }
            public SpearServiceType MethodType { get; set; }
        }
    }

    public record ServiceCatalogDto
    {
        public string Name { get; set; }
        public DataPlane DataPlane { get; set; }
        public IList<ServiceDefinitionDto> Services { get; set; }

        public record ServiceDefinitionDto
        {
            public string Name { get; set; }
            public SpearServiceType MethodType { get; set; }
        }
    }
}
