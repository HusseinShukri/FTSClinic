using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models.DbModels;
using System.Collections.Generic;

namespace PatientRegistrySystem.DB.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<int>, IDbModel

    {
        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public List<Record> Record { get; set; } = new List<Record>();
        public List<Employee> Employee { get; set; } = new List<Employee>();
        public List<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}
