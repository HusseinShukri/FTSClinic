using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
    public interface IUserRepository : IGenericRepository<UserDto,UserDto>
    {
        Task<List<UserDto>> GetAllDoctorsShallowAsync();
        Task<List<UserDto>> GetAllEmployeesShallowAsync();
    }
}
