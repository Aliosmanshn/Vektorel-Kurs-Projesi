using AutoMapper;
using Model.Dtos.AddressDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class AddressMapperProfile : Profile
    {
        public AddressMapperProfile()
        {
            CreateMap<Address, AddressGetDto>()
                   .ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.Namesurname))
                   .ForMember(dst => dst.CountryName, X => X.MapFrom(src => src.Country.Country1))
                   .ForMember(dst => dst.CityName, X => X.MapFrom(src => src.City.City1))
                   .ForMember(dst => dst.TownName, X => X.MapFrom(src => src.Town.Town1))
                   .ForMember(dst => dst.DistrictName, X => X.MapFrom(src => src.District.District1));
            CreateMap<AddressPostDto, Address>();
            CreateMap<AddressPutDto, Address>();
        }
    }
}
