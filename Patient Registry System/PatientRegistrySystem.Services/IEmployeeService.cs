using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.Box;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IEmployeeService
    {
        Task<List<UserDto>> GetAllEmployessAsync();
        Task<IdentityResult> CreateEmployesAsync(ApplicationUserEmployeeBoxDto boxDto);
    }
}
