using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.Domain.Dto;

namespace PatientRegistrySystem.DB.Models.DbModels
{
    public class ApplicationUserCreateModel : IDomainModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
