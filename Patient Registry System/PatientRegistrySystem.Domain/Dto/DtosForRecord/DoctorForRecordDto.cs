using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto.DtosForRecord
{
    public class DoctorForRecordDto
    {
        [Display(Name = "Doctor User")]
        public UserForRecoedDto User { get; set; }
        [Display(Name = "Clinic work for Adress 1")]
        public string Address1 { get; set; }
        [Display(Name = "Clinic work for Adress 2")]
        public string Address2 { get; set; }
    }
}
