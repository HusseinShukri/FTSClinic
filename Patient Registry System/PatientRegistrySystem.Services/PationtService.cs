using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class PationtService : IPationtService
    {
        private readonly IPationtRepository _pationtRepository;

        public PationtService(IPationtRepository pationtRepository)
        {
            _pationtRepository = pationtRepository;
        }

        public async Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _pationtRepository.CreateApplicationUser(applicationUser,Password);
        }
    }
}
