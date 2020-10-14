using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(int id);
        Task<bool> UpdateUserAsync(int userId, UserDto updatedUser);
        Task<CreatedUserDto> CreateUserAsync(UserDto newUser);
        Task<bool> DeleteUserAsync(int userId);
    }
}
