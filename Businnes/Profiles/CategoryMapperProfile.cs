using AutoMapper;
using Model.Dtos.CategoryDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Categories, CategoryGetDto>();
            CreateMap<CategoryPostDto, Categories>();
            CreateMap<CategoryPutDto, Categories>();
        }
        

    }
}
