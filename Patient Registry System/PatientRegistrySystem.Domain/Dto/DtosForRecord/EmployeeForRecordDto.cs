using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto.DtosForRecord
{
    public class EmployeeForRecordDto
    {
        [Display(Name = "Clinic work for Adress")]
        public string Adress { get; set; }
        [Display(Name = "Employee User")]
        public UserForRecoedDto User { get; set; }
    }
}
