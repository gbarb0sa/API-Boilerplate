using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Core.Models.Responses;

namespace Core.Mapping
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender.GetEnumDescription()));
        }
    }
}