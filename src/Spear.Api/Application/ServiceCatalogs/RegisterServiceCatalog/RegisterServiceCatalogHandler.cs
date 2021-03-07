using AutoMapper;
using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Api.Application.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition
{
    public class RegisterServiceCatalogHandler : ICommandHandler<RegisterServiceCatalogCommand, ServiceCatalogDto>
    {
        private readonly ISpearRegisterationAgent _registerationAgent;
        private readonly IMapper _mapper;

        public RegisterServiceCatalogHandler(ISpearEngine registerationAgent, IMapper mapper)
        {
            _registerationAgent =
                registerationAgent?.Registeration() ?? throw new System.ArgumentNullException(nameof(registerationAgent));

            _mapper =
                mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceCatalogDto> Handle(RegisterServiceCatalogCommand request, CancellationToken cancellationToken)
        {
            //TODO use mapper istead
            var serviceCatalog = new ServiceCatalogDefinition(request.Name, request.DataPlane)
            {
                Services = request.Services.Select(t => new ServiceDefinition(t.Name, t.MethodType)).ToList()
            };

            _registerationAgent.Register(serviceCatalog);

            return await Task.FromResult(_mapper.Map<ServiceCatalogDto>(serviceCatalog));
        }
    }
}
