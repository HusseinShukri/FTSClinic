using AutoMapper;
using PatientRegistrySystem.Domain.Dto;

namespace PatientRegistrySystem.Domain.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUserDto, UserDto>();
        }
    }
}
