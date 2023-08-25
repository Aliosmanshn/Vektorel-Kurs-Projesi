using AutoMapper;
using Model.Dtos.TripDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class TripMapperProfile : Profile
    {
        public TripMapperProfile()
        {
            CreateMap<Trip, TripGetDto>()
                   .ForMember(dst => dst.KategoriName, X => X.MapFrom(src => src.Kategori.CategoryName));

            CreateMap<TripPostDto, Trip>();
            CreateMap<TripPutDto, Trip>();
        }
    }
}
