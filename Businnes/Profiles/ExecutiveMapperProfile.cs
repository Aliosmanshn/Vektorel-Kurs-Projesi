using AutoMapper;
using Model.Dtos.ExecutiveDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class ExecutiveMapperProfile : Profile
    {
        public ExecutiveMapperProfile()
        {
            CreateMap<Executive, ExecutiveGetDto>();             
            CreateMap<ExecutivePostDto, Executive>();
            CreateMap<ExecutivePutDto, Executive>();
        }
    }
}
