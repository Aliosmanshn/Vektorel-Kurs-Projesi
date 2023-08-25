using AutoMapper;
using Model.Dtos.UserDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
} 
