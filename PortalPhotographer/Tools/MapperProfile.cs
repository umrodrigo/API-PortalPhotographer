using Api.View;
using AutoMapper;
using Data.Models;

namespace Api.Tools
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<EntityUserView, EntityUser>().ReverseMap();
        }
    }
}
