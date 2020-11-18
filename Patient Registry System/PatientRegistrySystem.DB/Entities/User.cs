using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.DB.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [StringLength(30)]
        [Required(ErrorMessage = "The FirstName is required")]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "The LastName is required")]
        public string LastName { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "The Login is required")]
        public string Login { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
        public List<Record> Record { get; set; } = new List<Record>();
        public List<Employee> Employee { get; set; } = new List<Employee>();
        public List<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}
