using AutoMapper;
using PlatofrmService.Dtos;
using PlatofrmService.Models;

namespace PlatofrmService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}