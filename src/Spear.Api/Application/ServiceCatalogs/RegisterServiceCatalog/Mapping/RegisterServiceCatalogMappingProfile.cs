using AutoMapper;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition;

namespace Spear.Api.Application.ServiceCatalogs.RegisterServiceCatalog.Mapping
{
    public class RegisterServiceCatalogMappingProfile : Profile
    {
        public RegisterServiceCatalogMappingProfile()
        {
            CreateMap<ServiceCatalogDefinition, ServiceCatalogDto>();
            CreateMap<ServiceDefinition, ServiceCatalogDto.ServiceDefinitionDto>();
        }
    }
}
