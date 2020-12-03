using PatientRegistrySystem.Domain.Dto.DtosForRecord;
using PatientRegistrySystem.Domain.Status;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class RecordDto
    {
        [Display(Name = "Patinet name")]
        public string PatinetName { get; set; }

        [Display(Name = "Doctor")]
        public DoctorForRecordDto DoctorNameDto { get; set; }

        [Display(Name = "Presciption")]
        public PrescriptionDto PrescriptionDto { get; set; }

        [Display(Name = "From Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Patient Case")]
        public string Case { get; set; }

        [Display(Name = "More Information")]
        public string ExtrInfo { get; set; }

        [Display(Name = "Current Status")]
        public RecordStatus Status { get; set; }

        [Display(Name = "Approved By Emolyee")]
        public EmployeeForRecordDto ApprovedByDto { get; set; }
    }
}
