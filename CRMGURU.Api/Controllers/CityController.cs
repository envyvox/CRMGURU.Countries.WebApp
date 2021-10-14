using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMGURU.Services.City.Commands;
using CRMGURU.Services.City.Models;
using CRMGURU.Services.City.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMGURU.Api.Controllers
{
    [Route("cities")]
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<List<CityDto>>> GetCities()
        {
            return Ok(await _mediator.Send(new GetCitiesQuery()));
        }

        [HttpGet, Route("id/{id:guid}")]
        public async Task<ActionResult<CityDto>> GetCityById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCityByIdQuery(id)));
        }

        [HttpGet, Route("name/{name}")]
        public async Task<ActionResult<CityDto>> GetCityByName([FromRoute] string name)
        {
            return Ok(await _mediator.Send(new GetCityByNameQuery(name)));
        }

        [HttpPut, Route("")]
        public async Task<ActionResult<CityDto>> CreateCity(CreateCityCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
