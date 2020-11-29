using AutoMapper;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.Box;
using System;

namespace PatientRegistrySystem.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, RegistrationViewModel>().ReverseMap();
            CreateMap<UserDto, RegistrationDoctoreViewModel>().ReverseMap();
            CreateMap<UserDto, RegistrationEmployeeViewModel>().ReverseMap();
            CreateMap<User, RegistrationViewModel>().ReverseMap();
            CreateMap<User, RegistrationDoctoreViewModel>().ReverseMap();
            CreateMap<User, RegistrationEmployeeViewModel>().ReverseMap();
            CreateMap<RegistrationDoctoreViewModel, ApplicationUserDto>()
                .ForMember(dir => dir.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.PhoneNumber, opt => opt.MapFrom(src => src.Phone));
            //.ForMember(dir => dir.User.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dir => dir.User.LastName, opt => opt.MapFrom(src => src.LastName))
            //.ForMember(dir => dir.User.Login, opt => opt.MapFrom(src => src.Login))
            //.ForMember(dir => dir.User.Doctor, opt => opt.MapFrom
            //(src => new DoctorDto { Address1 = src.Address1, Address2 = src.Address2 }));

            CreateMap<RegistrationEmployeeViewModel, ApplicationUserDto>()
                .ForMember(dir => dir.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dir => dir.PhoneNumber, opt => opt.MapFrom(src => src.Phone));

            CreateMap<RegistrationDoctoreViewModel, ApplicationUserDoctorBoxDto>();

            CreateMap<RegistrationDoctoreViewModel, DoctorDto>()
                .ForMember(dir => dir.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dir => dir.Address2, opt => opt.MapFrom(src => src.Address2));
        }
    }
}
