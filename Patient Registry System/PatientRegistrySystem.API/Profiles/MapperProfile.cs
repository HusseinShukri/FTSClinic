using AutoMapper;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;

namespace PatientRegistrySystem.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, RegistrationViewModel>().ReverseMap();
            CreateMap<User, RegistrationViewModel>().ReverseMap();
        }
    }
}
