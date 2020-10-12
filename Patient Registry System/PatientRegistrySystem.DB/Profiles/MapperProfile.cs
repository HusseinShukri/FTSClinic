using AutoMapper;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Linq;

namespace PatientRegistrySystem.DB.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(r => r.Roles, r => r.MapFrom(rr => rr.UserRole.Select(ur => ur.Role)))
                .ForMember(e => e.Employee, e => e.MapFrom(ee => ee.Employee))
                .ForMember(dir => dir.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dir => dir.Record, opt => opt.MapFrom(src => src.Record))
                .ReverseMap()
                .ForMember(r => r.UserRole, opt => opt.Ignore())
                .ForMember(e => e.Employee, opt => opt.Ignore())
                .ForMember(d => d.Doctor, opt => opt.Ignore())
                .ForMember(dir => dir.Record, opt => opt.Ignore())
                ;

            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Company, CompanyDto>()
                .ForMember(dir=>dir.Name,opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dir=>dir.Address,opt=>opt.MapFrom(src=>src.Address))
                .ReverseMap();

            CreateMap<Medicine, MedicineDto>()
                .ForMember(dir=>dir.Name , opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dir=>dir.company , opt=>opt.MapFrom(src=>src.Company))
                .ReverseMap();

            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dir => dir.LabTest, opt => opt.MapFrom(src =>src.LabTest))
                .ForMember(dir => dir.ExtraInformation, opt => opt.MapFrom(src =>src.ExtraInformation))
                .ForMember(dir => dir.ExpiryDate, opt => opt.MapFrom(src =>src.ExpiryDate))
                .ForMember(dir => dir.Medicines, opt => opt.MapFrom(src =>src.Medicines))
                .ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<Record, RecordDto>()
                .ForMember(dir => dir.PatinetName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dir => dir.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor.User.FirstName} {src.Doctor.User.LastName}"))
                .ForMember(dir => dir.Prescription, opt => opt.MapFrom(src=>src.Prescription))
                .ForMember(dir => dir.ApprovedBy, opt => opt.MapFrom(src => $"{src.Employee.User.FirstName} {src.Employee.User.LastName}"))
                .ReverseMap();
        }
    }
}
