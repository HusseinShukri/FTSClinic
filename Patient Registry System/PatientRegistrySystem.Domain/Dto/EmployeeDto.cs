using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class EmployeeDto : IDomainModel
    {
        [Display(Name ="Clinic work for Adress")]
        public string Adress { get; set; }
        [Display(Name = "Employee User")]
        public ApplicationUserDto ApplicationUserDto { get; set; }
        [Display(Name ="Work For")]
        public DoctorDto DoctorDto { get; set; }
    }
}
