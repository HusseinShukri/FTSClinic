using AutoMapper;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.DtosForRecord;
using System.Collections.Generic;

namespace PatientRegistrySystem.DB.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dir => dir.DoctorDto, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<DoctorDto>>(src.Doctor)))
                .ForMember(dir => dir.EmployeeDto, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<EmployeeDto>>(src.Employee)))
                .ForMember(dir => dir.RecordDto, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<RecordDto>>(src.Record)))
                .ReverseMap()
                .ForMember(dir => dir.Doctor, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<Doctor>>(src.DoctorDto)))
                .ForMember(dir => dir.Employee, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<Employee>>(src.EmployeeDto)))
                .ForMember(dir => dir.Record, opt => opt.MapFrom((src, dir, opt, context) => context.Mapper.Map<List<Record>>(src.RecordDto)));

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dir => dir.ApplicationUserDto, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dir => dir.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dir => dir.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dir => dir.Address2, opt => opt.MapFrom(src => src.Address2))
                .ReverseMap();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dir => dir.ApplicationUserDto, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dir => dir.DoctorDto, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dir => dir.Adress, opt => opt.MapFrom(src => src.Adress))
                .ReverseMap();

            CreateMap<Record, RecordDto>()
                .ForMember(dir => dir.PatinetName, opt => opt.MapFrom(src => $"{src.ApplicationUser.FirstName} {src.ApplicationUser.LastName}"))
                .ForMember(dir => dir.DoctorNameDto, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dir => dir.PrescriptionDto, opt => opt.MapFrom(src => src.Prescription))
                .ForMember(dir => dir.ApprovedByDto, opt => opt.MapFrom(src => src.Employee))
                .ReverseMap();

            CreateMap<Company, CompanyDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Medicine, MedicineDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.CompanyDto, opt => opt.MapFrom(src => src.Company))
                .ReverseMap();

            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dir => dir.LabTest, opt => opt.MapFrom(src => src.LabTest))
                .ForMember(dir => dir.ExtraInformation, opt => opt.MapFrom(src => src.ExtraInformation))
                .ForMember(dir => dir.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ReverseMap();

            CreateMap<Employee, EmployeeForRecordDto>();

            CreateMap<Doctor, DoctorForRecordDto>();
        }
    }
}