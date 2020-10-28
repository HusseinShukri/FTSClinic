using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    /// <summary>
    /// An user for update and create users
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        /// <summary>
        /// User login 
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Login { get; set; }
        /// <summary>
        /// User password 
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        /// <summary>
        /// User email address
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// User phone number
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
        public List<DoctorDto> Doctor { get; set; } = new List<DoctorDto>();
        public List<EmployeeDto> Employee { get; set; } = new List<EmployeeDto>();
        public List<RecordDto> Record { get; set; } = new List<RecordDto>();
    }
}
