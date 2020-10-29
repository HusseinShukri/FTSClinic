using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class EmployeeDto
    {
        [Display(Name ="Clinic work for Adress")]
        public string Adress { get; set; }
        [Display(Name = "Employee User")]
        public UserDto User { get; set; }
        [Display(Name ="Work For")]
        public DoctorDto Doctor { get; set; }
    }
}
