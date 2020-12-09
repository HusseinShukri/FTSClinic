using System;
using System.Collections.Generic;

namespace PatientRegistrySystem.Domain.Dto
{
    public class PrescriptionDto : IDomainModel
    {
        public string LabTest { get; set; }
        public List<MedicineDto> MedicinesDto { get; set; }
        public string ExtraInformation { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
