using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
   public interface IPationtRepository : IGenericRepository<IdentityResult, ApplicationUserDto>
    {
        Task<IdentityResult> CreateApplicationUser(ApplicationUserDto applicationUser, string Password);
    }
}
