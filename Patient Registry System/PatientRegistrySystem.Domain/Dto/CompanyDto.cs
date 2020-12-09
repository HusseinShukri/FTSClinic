using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class CompanyDto : IDomainModel
    {
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        [Display(Name = "Company Adress")]
        public string Address { get; set; }
        [Display(Name="Company Medicines")]
        public List<MedicineDto> MedicineDto { get; set; }
    }
}
