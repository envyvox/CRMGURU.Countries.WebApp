using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.City.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.City.Commands
{
    public record CreateCityCommand(string Name) : IRequest<CityDto>;

    public class CreateCityHandler : IRequestHandler<CreateCityCommand, CityDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CreateCityHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(CreateCityCommand request, CancellationToken ct)
        {
            var exist = await _db.Cities
                .AnyAsync(x => x.Name == request.Name);

            if (exist)
            {
                throw new AlreadyExistException($"City with name {request.Name} already exist");
            }

            var created = _db.Cities.Add(new Data.Entities.City
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            });

            await _db.SaveChangesAsync();

            return _mapper.Map<CityDto>(created.Entity);
        }
    }
}
