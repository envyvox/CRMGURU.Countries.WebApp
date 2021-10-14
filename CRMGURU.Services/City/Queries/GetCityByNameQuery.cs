using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.City.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.City.Queries
{
    public record GetCityByNameQuery(string Name) : IRequest<CityDto>;

    public class GetCityByNameHandler : IRequestHandler<GetCityByNameQuery, CityDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetCityByNameHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityByNameQuery request, CancellationToken ct)
        {
            var entity = await _db.Cities
                .SingleOrDefaultAsync(x => x.Name == request.Name);

            if (entity is null)
            {
                throw new NotFoundException($"City with name {request.Name} not found");
            }

            return _mapper.Map<CityDto>(entity);
        }
    }
}
