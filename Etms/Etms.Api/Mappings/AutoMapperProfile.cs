using AutoMapper;

namespace Etms.Api.Mappings
{
    using Core.Dtos;
    using Core.Entities;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, NewUserDto>().ReverseMap();
            CreateMap<TimeLog, TimeLogDto>()
                .ForMember(m => m.Email, o => o.MapFrom(tl => tl.User.Email))
                .ReverseMap();
        }
    }
}