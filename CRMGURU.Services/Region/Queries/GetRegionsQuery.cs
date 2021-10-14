using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.Region.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMGURU.Services.Region.Queries
{
    public record GetRegionsQuery : IRequest<List<RegionDto>>;

    public class GetRegionsHandler : IRequestHandler<GetRegionsQuery, List<RegionDto>>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetRegionsHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<RegionDto>> Handle(GetRegionsQuery request, CancellationToken ct)
        {
            var entities = await _db.Regions
                .ToListAsync();

            return _mapper.Map<List<RegionDto>>(entities);
        }
    }
}
