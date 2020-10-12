using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<bool> UpdateUser(int userId, UserDto updatedUser);
        Task<User> CreateUser(UserDto newUser);
        Task<bool> DeleteUser(int userId);
    }
}
