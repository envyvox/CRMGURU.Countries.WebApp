using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.Country.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMGURU.Services.Country.Queries
{
    public record GetCountriesQuery : IRequest<List<CountryDto>>;

    public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetCountriesHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken ct)
        {
            var entities = await _db.Countries
                .Include(x => x.Capital)
                .Include(x => x.Region)
                .ToListAsync();

            return _mapper.Map<List<CountryDto>>(entities);
        }
    }
}
