using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMGURU.Services.Region.Commands;
using CRMGURU.Services.Region.Models;
using CRMGURU.Services.Region.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMGURU.Api.Controllers
{
    [Route("regions")]
    public class RegionController : BaseController
    {
        private readonly IMediator _mediator;

        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<List<RegionDto>>> GetRegions()
        {
            return Ok(await _mediator.Send(new GetRegionsQuery()));
        }

        [HttpGet, Route("id/{id:guid}")]
        public async Task<ActionResult<RegionDto>> GetRegionById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetRegionByIdQuery(id)));
        }

        [HttpGet, Route("name/{name}")]
        public async Task<ActionResult<RegionDto>> GetRegionByName([FromRoute] string name)
        {
            return Ok(await _mediator.Send(new GetRegionByNameQuery(name)));
        }

        [HttpPut, Route("")]
        public async Task<ActionResult<RegionDto>> CreateRegion(CreateRegionCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
