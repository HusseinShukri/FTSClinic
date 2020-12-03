using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Hellper;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.RolesApplicationUserRepository
{
    public class RolesApplicationUserRepository : IRolesApplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public RolesApplicationUserRepository(IMapper mapper, IAplicationUserRepository aplicationUserRepository)
        {
            _mapper = mapper;
            _aplicationUserRepository = aplicationUserRepository;
        }

        public async Task<IdentityResult> CreateUserRoleAsync(ApplicationUserDto applicationUser, string Password, string userRoles)
        {
            if (!userRoles.IsValedRole())
            {
                throw new System.Exception("Invaled Role Name");
            }
            var applicationUserUserRole = _mapper.Map<ApplicationUser>(applicationUser);
            var result = _aplicationUserRepository.CreateApplicationUserAsync(applicationUserUserRole, Password);
            if (result.Result.Succeeded)
            {
                await _aplicationUserRepository.AddToRoleToApplicationUserAsync(applicationUserUserRole, userRoles);
            }
            return result.Result;
        }
        public async Task<IdentityResult> DeleteUserRoleDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserDeepAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteUserRoleSoftAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserSoftAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<ApplicationUserDto> FindUserRoleUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetUserRoleAsync(int userId, string userRoles)
        {
            return await _aplicationUserRepository.GetApplicationUserAsync(userId, userRoles);
        }

        public async Task<List<ApplicationUserDto>> GetAllUserRoleAsync(string userRoles)
        {
            return await _aplicationUserRepository.GetAllApplicationUsersAsync(userRoles);
        }

        public async Task<IdentityResult> UpdateUserRoleAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.UpdateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}
