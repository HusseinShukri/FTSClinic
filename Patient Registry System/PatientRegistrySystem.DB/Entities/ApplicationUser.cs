using Microsoft.AspNetCore.Identity;

namespace PatientRegistrySystem.DB.Entities
{
   public class ApplicationUser : IdentityUser
    {
        public User User { get; set; }
    }
}
