using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos.PationrRepository;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IdentityResult> CreatePatientAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _patientRepository.CreatePatientAsync(applicationUser,Password);
        }

        public async Task<IdentityResult> DeletePatientDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _patientRepository.DeletePatientDeepAsync(await _patientRepository.FindPatientUserAsync(claimsPrincipal));
        }

        public async Task<IdentityResult> DeletePatientSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _patientRepository.DeletePatientSoftAsync(await _patientRepository.FindPatientUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindPatientUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _patientRepository.FindPatientUserAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllPatientAsync()
        {
            return await _patientRepository.GetAllPatientAsync();
        }

        public async Task<ApplicationUserDto> GetPatientAsync(int userId)
        {
            return await _patientRepository.GetPatientAsync(userId);
        }

        public async Task<IdentityResult> UpdatePatientAsync(ApplicationUserDto applicationUser)
        {
            return await _patientRepository.UpdatePatientAsync(applicationUser);
        }
    }
}
