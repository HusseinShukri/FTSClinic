using AutoMapper;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.DtosForRecord;

namespace PatientRegistrySystem.DB.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dir => dir.User, opt => opt.MapFrom(src => src.User))
                //.ForMember(dir => dir.User.Doctor, opt => opt.MapFrom(src => src.User.Doctor))
                //.ForMember(dir => dir.User.Employee, opt => opt.MapFrom(src => src.User.Employee))
                .ReverseMap();

            CreateMap<User, UserForRecoedDto>();

            CreateMap<User, UserDto>()
                .ForMember(dir => dir.ApplicationUserDto, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dir => dir.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dir => dir.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dir => dir.Record, opt => opt.MapFrom(src => src.Record))
                .ReverseMap()
                .ForMember(dir => dir.ApplicationUser, opt => opt.Ignore())
                .ForMember(dir => dir.Employee, opt => opt.Ignore())
                .ForMember(dir => dir.Doctor, opt => opt.Ignore())
                .ForMember(dir => dir.Record, opt => opt.Ignore());


            CreateMap<Employee, EmployeeDto>()
                .ForMember(dir => dir.Adress, opt => opt.MapFrom(src => src.Adress))
                .ForMember(dir => dir.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dir => dir.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ReverseMap();

            CreateMap<Employee, EmployeeForRecordDto>();

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dir => dir.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dir => dir.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dir => dir.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dir => dir.Address2, opt => opt.MapFrom(src => src.Address2))
                .ReverseMap();
            CreateMap<Doctor, DoctorForRecordDto>();

            CreateMap<Company, CompanyDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Medicine, MedicineDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.Company, opt => opt.MapFrom(src => src.Company))
                .ReverseMap();

            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dir => dir.LabTest, opt => opt.MapFrom(src => src.LabTest))
                .ForMember(dir => dir.ExtraInformation, opt => opt.MapFrom(src => src.ExtraInformation))
                .ForMember(dir => dir.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ReverseMap();

            CreateMap<Record, RecordDto>()
                .ForMember(dir => dir.PatinetName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dir => dir.DoctorName, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dir => dir.Prescription, opt => opt.MapFrom(src => src.Prescription))
                .ForMember(dir => dir.ApprovedBy, opt => opt.MapFrom(src => src.Employee))
                .ReverseMap();
        }
    }
}