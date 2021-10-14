using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMGURU.Services.Country.Commands;
using CRMGURU.Services.Country.Models;
using CRMGURU.Services.Country.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMGURU.Api.Controllers
{
    [Route("countries")]
    public class CountryController : BaseController
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<List<CountryDto>>> GetCountries()
        {
            return Ok(await _mediator.Send(new GetCountriesQuery()));
        }

        [HttpGet, Route("id/{id:guid}")]
        public async Task<ActionResult<CountryDto>> GetCountryById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCountryByIdQuery(id)));
        }

        [HttpGet, Route("name/{name}")]
        public async Task<ActionResult<CountryDto>> GetCountryByName([FromRoute] string name)
        {
            return Ok(await _mediator.Send(new GetCountryByNameQuery(name)));
        }

        [HttpPut, Route("")]
        public async Task<ActionResult<CountryDto>> CreateCountry(CreateCountryCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
