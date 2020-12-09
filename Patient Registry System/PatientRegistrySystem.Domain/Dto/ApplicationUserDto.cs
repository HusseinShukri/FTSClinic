using System.Collections.Generic;

namespace PatientRegistrySystem.Domain.Dto
{
   public class ApplicationUserDto : IDomainModel
    {
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string SecurityStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public bool IsDeleted { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }

        public List<RecordDto> RecordDto { get; set; } = new List<RecordDto>();
        public List<EmployeeDto> EmployeeDto { get; set; } = new List<EmployeeDto>();
        public List<DoctorDto> DoctorDto { get; set; } = new List<DoctorDto>();
    }
}
