using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
   public interface IUserManagerRepository
    {
        Task<ApplicationUserDto> GetApplicationUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<UserDto> GetUserByIdentityIdAsync(string identityId);
        Task<ApplicationUserDto> GetApplicationUseerByIdentityClamAsync(ClaimsPrincipal claimsPrincipal);
       
    }
}
