using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.Region.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.Region.Queries
{
    public record GetRegionByNameQuery(string Name) : IRequest<RegionDto>;

    public class GetRegionByNameHandler : IRequestHandler<GetRegionByNameQuery, RegionDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetRegionByNameHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RegionDto> Handle(GetRegionByNameQuery request, CancellationToken ct)
        {
            var entity = await _db.Regions
                .SingleOrDefaultAsync(x => x.Name == request.Name);

            if (entity is null)
            {
                throw new NotFoundException($"Region with name {request.Name} not found");
            }

            return _mapper.Map<RegionDto>(entity);
        }
    }
}
