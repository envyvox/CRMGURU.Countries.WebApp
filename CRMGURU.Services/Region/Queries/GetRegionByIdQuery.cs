using System;
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
    public record GetRegionByIdQuery(Guid Id) : IRequest<RegionDto>;

    public class GetRegionByIdHandler : IRequestHandler<GetRegionByIdQuery, RegionDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetRegionByIdHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RegionDto> Handle(GetRegionByIdQuery request, CancellationToken ct)
        {
            var entity = await _db.Regions
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                throw new NotFoundException($"Region with id {request.Id} not found");
            }

            return _mapper.Map<RegionDto>(entity);
        }
    }
}
