using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(int id);
        Task<bool> UpdateUserAsync(UserDto updatedUser);
        Task<bool> DeleteUserAsync(int userId);
    }
}
