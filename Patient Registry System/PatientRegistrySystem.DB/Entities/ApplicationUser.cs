using Microsoft.AspNetCore.Identity;

namespace PatientRegistrySystem.DB.Entities
{
   public class ApplicationUser : IdentityUser
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
