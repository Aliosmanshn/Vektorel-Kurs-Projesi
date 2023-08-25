using AutoMapper;
using Model.Dtos.CommentDto;
using Model.Entities;

namespace Businness.Profiles
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Comment, CommentGetDto>()
              .ForMember(dst => dst.TripName, X => X.MapFrom(src => src.Trip.TripnName));
            


            CreateMap<CommentPostDto, Comment>();
            CreateMap<CommentPutDto, Comment>();
        }
    }
}
