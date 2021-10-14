using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.Region.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.Region.Commands
{
    public record CreateRegionCommand(string Name) : IRequest<RegionDto>;

    public class CreateRegionHandler : IRequestHandler<CreateRegionCommand, RegionDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CreateRegionHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RegionDto> Handle(CreateRegionCommand request, CancellationToken ct)
        {
            var exist = await _db.Regions
                .AnyAsync(x => x.Name == request.Name);

            if (exist)
            {
                throw new AlreadyExistException($"Region with name {request.Name} already exist");
            }

            var created = _db.Regions.Add(new Data.Entities.Region
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            });

            await _db.SaveChangesAsync();

            return _mapper.Map<RegionDto>(created.Entity);
        }
    }
}
