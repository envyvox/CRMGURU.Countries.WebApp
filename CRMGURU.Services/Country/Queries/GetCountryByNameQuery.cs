using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.City.Models;
using CRMGURU.Services.Country.Models;
using CRMGURU.Services.Region.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.Country.Queries
{
    public record GetCountryByNameQuery(string Name) : IRequest<CountryDto>;

    public class GetCountryByNameHandler : IRequestHandler<GetCountryByNameQuery, CountryDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly RestCountriesOptions _options;

        public GetCountryByNameHandler(
            AppDbContext db,
            IMapper mapper,
            IOptions<RestCountriesOptions> options)
        {
            _db = db;
            _mapper = mapper;
            _options = options.Value;
        }

        public async Task<CountryDto> Handle(GetCountryByNameQuery request, CancellationToken ct)
        {
            var entity = await _db.Countries
                .Include(x => x.Capital)
                .Include(x => x.Region)
                .SingleOrDefaultAsync(x => x.Name == request.Name);

            if (entity is null)
            {
                var client = new RestClient($"{_options.BaseUrl}name/{request.Name}");

                try
                {
                    var response = await client.ExecuteAsync(new RestRequest(Method.GET), ct);

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:

                            var model = JsonConvert.DeserializeObject<RestCountryDto[]>(response.Content).First();

                            return new CountryDto
                            {
                                Id = Guid.Empty,
                                Name = model.Name.Common,
                                Code = model.Cca2,
                                Area = model.Area,
                                Population = model.Population,
                                Capital = new CityDto(Guid.Empty, model.Capital.First()),
                                Region = new RegionDto(Guid.Empty, model.Region)
                            };
                        case HttpStatusCode.NotFound:

                            throw new NotFoundException($"Country with name {request.Name} not found");

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return _mapper.Map<CountryDto>(entity);
        }
    }
}
