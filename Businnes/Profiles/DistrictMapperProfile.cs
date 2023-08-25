using AutoMapper;
using Model.Dtos.DistrictDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class DistrictMapperProfile : Profile
    {
        public DistrictMapperProfile()
        {
            CreateMap<District, DistrictGetDto>();
            CreateMap<DistrictPostDto, District>();
            CreateMap<DistrictPutDto, District>();
        }
    }
}
