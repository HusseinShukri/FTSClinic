﻿using System;

namespace PatientRegistrySystem.Domain.Dto
{
    public class MedicineDto
    {
        public String Name { get; set; }
        public CompanyDto company { get; set; }
    }
}
