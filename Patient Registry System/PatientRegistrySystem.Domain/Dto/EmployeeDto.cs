using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class EmployeeDto
    {
        [Display(Name ="Clinic work for Adress")]
        public string Adress { get; set; }
        [Display(Name = "Employee Name")]
        public string UserName { get; set; }
        [Display(Name ="Work For")]
        public string DoctorName { get; set; }
    }
}
