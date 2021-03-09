using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.Queries;
using Spear.Api.Application.ServiceCatalogs.GetServiceDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spear.Api.Application.ServiceCatalogs.GetServiceCatalog
{
    internal class GetServiceCatalogHandler : IQueryHandler<GetServiceCatalogQuery, IEnumerable<ServiceCatalogDto>>
    {
        private readonly ISpearDiscoveryAgent _discoveryAgent;

        public GetServiceCatalogHandler(ISpearEngine discoveryAgent)
        {
            _discoveryAgent =
                discoveryAgent?.Discovery() ?? throw new ArgumentNullException(nameof(discoveryAgent));
        }

        public async Task<IEnumerable<ServiceCatalogDto>> Handle(
            GetServiceCatalogQuery request,
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            IEnumerable<ServiceCatalogDefinition> response;

            switch (request.Name, request.DataPlane)
            {
                case (null, not null):
                    response = _discoveryAgent.DiscoverAllServices((DataPlane)Enum.Parse(
                        typeof(DataPlane),
                        request.DataPlane!,
                        true));
                    break;
                case (not null, null):
                    response = _discoveryAgent.DiscoverAllServices(
                        request.Name!);
                    break;
                case (not null, not null):
                    var serviceDefinition = 
                        _discoveryAgent.DiscoverService(
                            request.Name!,
                            (DataPlane)Enum.Parse(typeof(DataPlane), request.DataPlane!, true));
                    response = serviceDefinition == null ?
                        new List<ServiceCatalogDefinition>() { } :
                        new List<ServiceCatalogDefinition>() { serviceDefinition };
                    break;
                default:
                    response = _discoveryAgent.DiscoverAllServices();
                    break;
            }

            return await Task.FromResult(response.Select(t => TypeMapper.ToServiceCatalogDto(t)));
        }
    }
}
