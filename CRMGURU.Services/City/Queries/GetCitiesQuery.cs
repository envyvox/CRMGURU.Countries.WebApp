using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.City.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMGURU.Services.City.Queries
{
    public record GetCitiesQuery : IRequest<List<CityDto>>;

    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, List<CityDto>>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetCitiesHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken ct)
        {
            var entities = await _db.Cities
                .ToListAsync();

            return _mapper.Map<List<CityDto>>(entities);
        }
    }
}
