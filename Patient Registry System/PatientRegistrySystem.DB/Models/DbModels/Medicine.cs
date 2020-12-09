using PatientRegistrySystem.DB.Models.DbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PatientRegistrySystem.DB.Models
{
    public class Medicine : IDbModel
    {
        [Key]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Yhe Medicine Name is required")]
        [StringLength(30)]
        public string Name { get; set; }

        [ForeignKey(nameof(Company))]
        [Required(ErrorMessage = "The Company is required")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public Prescription Prescription { get; set; }
    }
}
