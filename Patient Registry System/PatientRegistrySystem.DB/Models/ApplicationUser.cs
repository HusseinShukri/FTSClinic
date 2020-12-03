using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PatientRegistrySystem.DB.Models
{
    public class ApplicationUser : IdentityUser<int>

    {
        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }

        public List<Record> Record { get; set; } = new List<Record>();
        public List<Employee> Employee { get; set; } = new List<Employee>();
        public List<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}
