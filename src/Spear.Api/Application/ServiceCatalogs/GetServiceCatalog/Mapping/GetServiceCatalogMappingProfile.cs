using AutoMapper;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.ServiceCatalogs.GetServiceDefinition;

namespace Spear.Api.Application.ServiceCatalogs.GetServiceCatalog.Mapping
{
    public class GetServiceCatalogMappingProfile : Profile
    {

        public GetServiceCatalogMappingProfile()
        {
            CreateMap<ServiceCatalogDefinition, ServiceCatalogDto>();
            CreateMap<ServiceDefinition, ServiceCatalogDto.ServiceDefinitionDto>();
        }
    }
}
