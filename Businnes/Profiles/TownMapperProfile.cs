using AutoMapper;
using Model.Dtos.TownDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class TownMapperProfile : Profile
    {
        public TownMapperProfile()
        {
            CreateMap<Town, TownGetDto>()                   
                   .ForMember(dst => dst.CityName, X => X.MapFrom(src => src.City.Towns)).ReverseMap();
            CreateMap<TownPostDto, Town>().ReverseMap();
            CreateMap<TownPutDto, Town>().ReverseMap();
        }
    }
}
