using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.PationrRepository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMapper _mapper;
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public PatientRepository(IMapper mapper, IAplicationUserRepository aplicationUserRepository)
        {
            _mapper = mapper;
            _aplicationUserRepository = aplicationUserRepository;
        }

        public async Task<IdentityResult> CreatePatientAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserPatient = _mapper.Map<ApplicationUser>(applicationUser);
            var result = _aplicationUserRepository.CreateApplicationUserAsync(applicationUserPatient, Password);
            if (result.Result.Succeeded)
            {
                await _aplicationUserRepository.AddToRoleToApplicationUserAsync(applicationUserPatient, UserRoles.Patient);
            }
            return result.Result;
        }

        public async Task<IdentityResult> DeletePatientDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserDeepAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeletePatientSoftAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserSoftAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<ApplicationUserDto> FindPatientUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetPatientAsync(int userId)
        {
            return await _aplicationUserRepository.GetApplicationUserAsync(userId, UserRoles.Patient);
        }

        public async Task<List<ApplicationUserDto>> GetAllPatientAsync()
        {
            return await _aplicationUserRepository.GetAllApplicationUsersAsync(UserRoles.Patient);
        }

        public async Task<IdentityResult> UpdatePatientAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.UpdateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}
