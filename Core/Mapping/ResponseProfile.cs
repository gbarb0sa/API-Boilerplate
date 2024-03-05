using AutoMapper;
using Core.Entities;
using Core.Models.Responses;

namespace Core.Mapping
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}