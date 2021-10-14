using System;
using AutoMapper;

namespace CRMGURU.Services.Region.Models
{
    public record RegionDto(
        Guid Id,
        string Name);

    public class RegionToDtoProfile : Profile
    {
        public RegionToDtoProfile() => CreateMap<Data.Entities.Region, RegionDto>();
    }

    public class DtoToRegionProfile : Profile
    {
        public DtoToRegionProfile() => CreateMap<RegionDto, Data.Entities.Region>();
    }
}
