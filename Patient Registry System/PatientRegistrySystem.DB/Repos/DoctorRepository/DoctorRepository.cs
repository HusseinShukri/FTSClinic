using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.DoctorRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IMapper _mapper;
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public DoctorRepository(IMapper mapper, IAplicationUserRepository aplicationUserRepository)
        {
            _mapper = mapper;
            _aplicationUserRepository = aplicationUserRepository;
        }

        public async Task<IdentityResult> CreateDoctorAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserDoctor = _mapper.Map<ApplicationUser>(applicationUser);
            var result = _aplicationUserRepository.CreateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser), Password);
            if (result.Result.Succeeded)
            {
                await _aplicationUserRepository.AddToRoleToApplicationUserAsync(applicationUserDoctor, UserRoles.Doctor);
            }
            return result.Result;
        }

        public async Task<IdentityResult> DeleteDoctorDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserDeepAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteDoctorSoftAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserSoftAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<ApplicationUserDto> FindDoctorUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetDoctorAsync(int userId)
        {
            return await _aplicationUserRepository.GetApplicationUserAsync(userId, UserRoles.Doctor);
        }

        public async Task<List<ApplicationUserDto>> GetAllDoctorAsync()
        {
            return await _aplicationUserRepository.GetAllApplicationUsersAsync(UserRoles.Doctor);
        }

        public async Task<IdentityResult> UpdateDoctorAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.UpdateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}
