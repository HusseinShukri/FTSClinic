using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<bool> UpdateUserAsync(int userId, UserDto updatedUser);
        Task<User> CreateUserAsync(UserDto newUser);
        Task<bool> DeleteUserAsync(int userId);
    }
}
