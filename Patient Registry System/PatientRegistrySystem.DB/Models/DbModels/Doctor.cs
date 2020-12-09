using PatientRegistrySystem.DB.Models.IdentityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRegistrySystem.DB.Models.DbModels
{
    public class Doctor : IDbModel
    {
        [Key]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Required(ErrorMessage = "The User is required")]
        public int ApplicationUserId { get; set; }

        [Required(ErrorMessage = "The Adress is required")]
        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public List<Record> Record { get; set; } = new List<Record>();
    }
}
