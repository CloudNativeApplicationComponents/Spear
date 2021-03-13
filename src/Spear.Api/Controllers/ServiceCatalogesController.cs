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
    public class ServiceCatalogesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceCatalogesController(IMediator mediator)
        {
            _mediator =
                mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ServiceCatalogDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetServiceCatalogDefinition(
            [FromQuery] GetServiceCatalogQuery request)
        {
            var serviceDefinitions = await _mediator.Send(request);
            return Ok(serviceDefinitions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceCatalogDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterServiceCatalogDefinition(
            [FromBody] RegisterServiceCatalogCommand request)
        {
            var createdServiceDefinition = await _mediator.Send(request);

            //This must change to created at route
            return Created(string.Empty, createdServiceDefinition);
        }
    }
}
