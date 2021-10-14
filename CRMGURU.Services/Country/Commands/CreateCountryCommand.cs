using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.City.Commands;
using CRMGURU.Services.Country.Models;
using CRMGURU.Services.Region.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.Country.Commands
{
    public record CreateCountryCommand(
            string Name,
            string Code,
            double Area,
            uint Population,
            string CapitalName,
            string RegionName)
        : IRequest<CountryDto>;

    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CountryDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCountryHandler(
            AppDbContext db,
            IMapper mapper,
            IMediator mediator)
        {
            _db = db;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken ct)
        {
            var exist = await _db.Countries
                .AnyAsync(x => x.Name == request.Name);

            if (exist)
            {
                throw new AlreadyExistException($"Country with name {request.Name} already exist");
            }

            var capital = await _db.Cities
                .SingleOrDefaultAsync(x => x.Name == request.CapitalName);
            var region = await _db.Regions
                .SingleOrDefaultAsync(x => x.Name == request.RegionName);

            if (capital is null)
            {
                var createdCapital = await _mediator.Send(new CreateCityCommand(request.CapitalName));
                capital = _mapper.Map<Data.Entities.City>(createdCapital);
            }

            if (region is null)
            {
                var createdRegion = await _mediator.Send(new CreateRegionCommand(request.RegionName));
                region = _mapper.Map<Data.Entities.Region>(createdRegion);
            }

            var created = _db.Countries.Add(new Data.Entities.Country
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Code = request.Code,
                Area = request.Area,
                Population = request.Population,
                CapitalId = capital.Id,
                RegionId = region.Id
            });

            await _db.SaveChangesAsync();

            return _mapper.Map<CountryDto>(created.Entity);
        }
    }
}
