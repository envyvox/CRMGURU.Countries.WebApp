using System;
using AutoMapper;

namespace CRMGURU.Services.City.Models
{
    public record CityDto(
        Guid Id,
        string Name);

    public class CityToDtoProfile : Profile
    {
        public CityToDtoProfile() => CreateMap<Data.Entities.City, CityDto>();
    }

    public class DtoToCityProfile : Profile
    {
        public DtoToCityProfile() => CreateMap<CityDto, Data.Entities.City>();
    }
}
