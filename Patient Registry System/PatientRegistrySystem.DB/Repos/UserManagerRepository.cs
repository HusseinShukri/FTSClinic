using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationIdentityDbContext _ApplicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerRepository(IMapper mapper,
            ApplicationIdentityDbContext applicationIdentityDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _ApplicationDbContext = applicationIdentityDbContext;
        }

        public async Task<UserDto> GetUserByIdentityIdAsync(string identityId)
        {
            return _mapper.Map<UserDto>(await _ApplicationDbContext.User.AsNoTracking()
                    .Include(a => a.ApplicationUser)
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.User)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.User)
                    .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                    .Where(u => u.IsDeleted == false)
                    .FirstOrDefaultAsync(u => u.ApplicationUserId.Equals(identityId)));
        }

        public async Task<ApplicationUserDto> GetApplicationUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return _mapper.Map<ApplicationUserDto>(await _userManager.GetUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> GetApplicationUseerByIdentityClamAsync(ClaimsPrincipal claimsPrincipal)
        {
            var applicationuser = await GetApplicationUserAsync(claimsPrincipal);
            var user = await GetUserByIdentityIdAsync(applicationuser.Id);
            applicationuser.User = user;
            return applicationuser;
        }
    }
}
