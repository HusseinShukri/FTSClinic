using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class CompanyDto
    {
        [Display(Name="Company Name")]
        public string Name { get; set; }
        [Display(Name="Company Adress")]
        public string Address { get; set; }
    }
}
