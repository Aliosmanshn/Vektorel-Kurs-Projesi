using AutoMapper;
using Model.Dtos.CityDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class CityMapperProfile : Profile
    {
        public CityMapperProfile()
        {
            CreateMap<City, CityGetDto>()
              .ForMember(dst => dst.CountryName, X => X.MapFrom(src => src.Country.Country1));
            CreateMap<CityPostDto, City>();
            CreateMap<CityPutDto, City>();
        }
    }
}
