using AutoMapper;
using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.Queries;
using Spear.Api.Application.ServiceCatalogs.GetServiceDefinition;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Spear.Api.Application.ServiceCatalogs.GetServiceCatalog
{
    public class GetServiceCatalogHandler : IQueryHandler<GetServiceCatalogQuery, IList<ServiceCatalogDto>>
    {
        private readonly ISpearDiscoveryAgent _discoveryAgent;
        private readonly IMapper _mapper;

        public GetServiceCatalogHandler(ISpearEngine discoveryAgent, IMapper mapper)
        {
            _discoveryAgent =
                discoveryAgent?.Discovery() ?? throw new ArgumentNullException(nameof(discoveryAgent));
            _mapper =
                mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<ServiceCatalogDto>> Handle(GetServiceCatalogQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ServiceCatalogDefinition> response;

            switch (request.Name, request.DataPlane)
            {
                case (null, not null):
                    response = _discoveryAgent.DiscoverAllServices(request.DataPlane.Value);
                    break;
                case (not null, null):
                    response = _discoveryAgent.DiscoverAllServices(request.Name);
                    break;
                case (not null, not null):
                    var serviceDefinition = _discoveryAgent.DiscoverService(request.Name, request.DataPlane.Value);
                    response = serviceDefinition == null ? new List<ServiceCatalogDefinition>() { } : new List<ServiceCatalogDefinition>() { serviceDefinition };
                    break;
                default:
                    response = _discoveryAgent.DiscoverAllServices();
                    break;
            }

            return await Task.FromResult(_mapper.Map<List<ServiceCatalogDto>>(response));
        }
    }
}
