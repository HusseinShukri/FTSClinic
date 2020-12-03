using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IMapper _mapper;
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public AdminRepository(IMapper mapper, IAplicationUserRepository aplicationUserRepository)
        {
            _mapper = mapper;
            _aplicationUserRepository = aplicationUserRepository;
        }

        public async Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserAdmin = _mapper.Map<ApplicationUser>(applicationUser);
            var result = _aplicationUserRepository.CreateApplicationUserAsync(applicationUserAdmin, Password);
            if (result.Result.Succeeded)
            {
                await _aplicationUserRepository.AddToRoleToApplicationUserAsync(applicationUserAdmin, UserRoles.Admin);
            }
            return result.Result;
        }

        public async Task<IdentityResult> DeleteAdminDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserDeepAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteAdminSoftAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserSoftAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<ApplicationUserDto> FindAdminUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetAdminAsync(int userId)
        {
            return await _aplicationUserRepository.GetApplicationUserAsync(userId, UserRoles.Admin);
        }

        public async Task<List<ApplicationUserDto>> GetAllAdminAsync()
        {
            return await _aplicationUserRepository.GetAllApplicationUsersAsync(UserRoles.Admin);
        }

        public async Task<IdentityResult> UpdateAdminAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.UpdateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}
