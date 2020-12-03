using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos.DoctorRepository;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IdentityResult> CreateDoctorAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _doctorRepository.CreateDoctorAsync(applicationUser,Password);
        }

        public async Task<IdentityResult> DeleteDoctorDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _doctorRepository.DeleteDoctorDeepAsync(await _doctorRepository.FindDoctorUserAsync(claimsPrincipal));
        }

        public async Task<IdentityResult> DeleteDoctorSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _doctorRepository.DeleteDoctorSoftAsync(await _doctorRepository.FindDoctorUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindDoctorUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _doctorRepository.FindDoctorUserAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllDoctorAsync()
        {
            return await _doctorRepository.GetAllDoctorAsync();
        }

        public async Task<ApplicationUserDto> GetDoctorAsync(int userId)
        {
            return await _doctorRepository.GetDoctorAsync(userId);
        }

        public async Task<IdentityResult> UpdateDoctorAsync(ApplicationUserDto applicationUser)
        {
            return await _doctorRepository.UpdateDoctorAsync(applicationUser);
        }
    }

}
