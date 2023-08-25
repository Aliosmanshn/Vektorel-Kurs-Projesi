using AutoMapper;
using Model.Dtos.CountryDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<Country, CountryGetDto>();           
            CreateMap<CountryPostDto, Country>();
            CreateMap<CountryPutDto, Country>();
        }
    }
}
