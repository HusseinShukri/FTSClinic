using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository )
        {
            _adminRepository = adminRepository;
        }

        public async Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _adminRepository.CreateEntityAsync(applicationUser, Password);
        }
    }
}
