using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spear.Api.Application.ServiceCatalogs;
using Spear.Api.Application.ServiceCatalogs.GetServiceDefinition;
using Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Spear.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCatalogDefinitionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceCatalogDefinitionsController(IMediator mediator)
        {
            _mediator =
                mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ServiceCatalogDefinitionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetServiceCatalogDefinition(
            [FromQuery] GetServiceCatalogDefinitionQuery request)
        {
            var serviceDefinitions = await _mediator.Send(request);
            return Ok(serviceDefinitions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceCatalogDefinitionDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterServiceCatalogDefinition(
            [FromBody] ServiceCatalogDefinitionRegisterCommand request)
        {
            var createdServiceDefinition = await _mediator.Send(request);

            //This must change to created at route
            return Created(string.Empty, createdServiceDefinition);
        }
    }
}
