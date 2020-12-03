using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos.AdminRepository;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _adminRepository.CreateAdminAsync(applicationUser, Password);
        }

        public async Task<IdentityResult> DeleteAdminDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _adminRepository.DeleteAdminDeepAsync(await _adminRepository.FindAdminUserAsync(claimsPrincipal));
        }

        public async Task<IdentityResult> DeleteAdminSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _adminRepository.DeleteAdminSoftAsync(await _adminRepository.FindAdminUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindAdminUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _adminRepository.FindAdminUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetAdminAsync(int userId)
        {
            return await _adminRepository.GetAdminAsync(userId);
        }

        public async Task<List<ApplicationUserDto>> GetAllAdminAsync()
        {
            return await _adminRepository.GetAllAdminAsync();
        }

        public async Task<IdentityResult> UpdateAdminAsync(ApplicationUserDto applicationUser)
        {
            return await _adminRepository.UpdateAdminAsync(applicationUser);
        }
    }
}
