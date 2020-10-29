using AutoMapper;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.Domain.Dto;

namespace PatientRegistrySystem.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, GetUserViewModel>().
                ReverseMap().ForMember(dir=>dir.UserId,opt=>opt.Ignore());
        }
    }
}
