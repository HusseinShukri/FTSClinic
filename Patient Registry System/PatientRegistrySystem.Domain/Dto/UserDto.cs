using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Login { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUserDto ApplicationUserDto { get; set; } = new ApplicationUserDto();
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
        public List<DoctorDto> Doctor { get; set; } = new List<DoctorDto>();
        public List<EmployeeDto> Employee { get; set; } = new List<EmployeeDto>();
        public List<RecordDto> Record { get; set; } = new List<RecordDto>();
    }
}
