using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition
{
    internal class RegisterServiceCatalogHandler : ICommandHandler<RegisterServiceCatalogCommand, ServiceCatalogDto>
    {
        private readonly ISpearRegisterationAgent _registerationAgent;

        public RegisterServiceCatalogHandler(ISpearEngine registerationAgent)
        {
            _registerationAgent =
                registerationAgent?.Registeration() ?? throw new ArgumentNullException(nameof(registerationAgent));
        }

        public async Task<ServiceCatalogDto> Handle(
            RegisterServiceCatalogCommand request,
            CancellationToken cancellationToken)
        {
            var serviceCatalog = new ServiceCatalogDefinition(request.Name,
                (DataPlane)Enum.Parse(typeof(DataPlane), request.DataPlane, true));

            foreach (var service in request.Services)
                serviceCatalog.Services.Add(new ServiceDefinition(service.Name,
                    (SpearServiceType)Enum.Parse(typeof(SpearServiceType), service.MethodType, true)));

            _registerationAgent.Register(serviceCatalog);

            return await Task.FromResult(TypeMapper.ToServiceCatalogDto(serviceCatalog));
        }
    }
}
