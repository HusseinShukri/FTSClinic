using AutoMapper;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;

namespace PatientRegistrySystem.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, ApplicationUserDto>()
                .ForMember(dir => dir.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dir => dir.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dir => dir.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dir => dir.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dir => dir.IsDeleted, opt => opt.MapFrom(src => false))
                .ReverseMap();

            CreateMap<RegistrationDoctoreViewModel, ApplicationUserDto>()
                .ForMember(dir => dir.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dir => dir.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dir => dir.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dir => dir.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dir => dir.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dir => dir.DoctorDto, opt => opt.MapFrom((src, dest, destMember, context)
                    => new List<DoctorDto> {context.Mapper.Map<DoctorDto>(src) }))
                .ReverseMap();

            CreateMap<RegistrationDoctoreViewModel, DoctorDto>()
                .ForMember(dir => dir.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dir => dir.Address2, opt => opt.MapFrom(src => src.Address2))
                .ForMember(dir => dir.DoctorId, opt => opt.Ignore())
                .ForMember(dir => dir.ApplicationUserDto, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
