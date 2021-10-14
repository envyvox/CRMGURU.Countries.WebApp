using System;
using AutoMapper;
using CRMGURU.Services.City.Models;
using CRMGURU.Services.Region.Models;

namespace CRMGURU.Services.Country.Models
{
    public class CountryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
        public double Area { get; init; }
        public uint Population { get; init; }
        public CityDto Capital { get; init; }
        public RegionDto Region { get; init; }
    }

    public class CountryToDtoProfile : Profile
    {
        public CountryToDtoProfile() => CreateMap<Data.Entities.Country, CountryDto>();
    }

    public class DtoToCountryProfile : Profile
    {
        public DtoToCountryProfile() => CreateMap<CountryDto, Data.Entities.Country>();
    }
}
