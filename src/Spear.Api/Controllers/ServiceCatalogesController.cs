using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public ServiceCatalogesController(IMediator mediator, IMapper mapper)
        {
            _mediator =
                mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper =
                mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Application.ServiceCatalogs.GetServiceDefinition.ServiceCatalogDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetServiceDefinition([FromQuery] GetServiceCatalogQuery request)
        {
            var serviceDefinitionCommand = _mapper.Map<GetServiceCatalogQuery>(request);
            var serviceDefinitions = await _mediator.Send(serviceDefinitionCommand);
            return Ok(serviceDefinitions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Application.ServiceCatalogs.RegisterServiceDefinition.ServiceCatalogDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterServiceDefinition([FromBody] RegisterServiceCatalogCommand request)
        {
            var createdServiceDefinition = await _mediator.Send(request);
            
            //This must change to created at route
            return Created(string.Empty, createdServiceDefinition);
        }
    }
}
