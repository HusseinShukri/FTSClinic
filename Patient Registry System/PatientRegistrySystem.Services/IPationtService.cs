using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IPationtService
    {
        Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password);
    }
}
