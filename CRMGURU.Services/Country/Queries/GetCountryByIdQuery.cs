using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRMGURU.Data;
using CRMGURU.Services.Country.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CRMGURU.Data.Extensions.ExceptionExtensions;

namespace CRMGURU.Services.Country.Queries
{
    public record GetCountryByIdQuery(Guid Id) : IRequest<CountryDto>;

    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, CountryDto>
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public GetCountryByIdHandler(
            AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken ct)
        {
            var entity = await _db.Countries
                .Include(x => x.Capital)
                .Include(x => x.Region)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                throw new NotFoundException($"Country with id {request.Id} not found");
            }

            return _mapper.Map<CountryDto>(entity);
        }
    }
}
