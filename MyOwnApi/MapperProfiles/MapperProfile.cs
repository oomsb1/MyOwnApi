using AutoMapper;
using MyNewAPI.Application.DTOs;
using MyOwnAPI.Domain.Entities;

namespace MyOwnApi.MapperProfiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Driver, DriverDto>().ReverseMap();
        }
    }
}
