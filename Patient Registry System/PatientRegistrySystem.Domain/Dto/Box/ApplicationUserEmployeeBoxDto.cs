using System.Security.Claims;

namespace PatientRegistrySystem.Domain.Dto.Box
{
   public class ApplicationUserEmployeeBoxDto
    {
        public ApplicationUserDto ApplicationUserDto { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public ClaimsPrincipal claimsPrincipalUser { get; set; }
    }
}
