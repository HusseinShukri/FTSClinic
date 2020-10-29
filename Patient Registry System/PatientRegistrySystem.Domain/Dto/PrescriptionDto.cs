using System;
using System.Collections.Generic;

namespace PatientRegistrySystem.Domain.Dto
{
    public class PrescriptionDto
    {
        public string LabTest { get; set; }
        public List<MedicineDto> Medicines { get; set; }
        public string ExtraInformation { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
