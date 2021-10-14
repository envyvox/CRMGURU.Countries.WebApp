using System;
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
    public record GetCityByIdQuery(Guid Id) : IRequest<CityDto>;

    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetCityByIdHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken ct)
        {
            var entity = await _db.Cities
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                throw new NotFoundException($"City with id {request.Id} not found");
            }

            return _mapper.Map<CityDto>(entity);
        }
    }
}
