using AutoMapper;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper Mapper;
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Mapper = mapper;
            this.userRepository = userRepository;
        }
        //CreateUser/UpdateUser/DeleteUser/GetUser/GetAllUsers

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userFromDB = await userRepository.GetAllAsync();
            if (!userFromDB.Any()) { return null; }
            return userFromDB;
        }

        public async Task<User> GetUser(int id)
        {
            var userFromDB = await userRepository.GetIdAsync(id);
            if (userFromDB == null) { return null; }
            return userFromDB;
        }

        public async Task<bool> UpdateUser(int userId,UserDto updatedUser)
        {
            var userFromDB = await userRepository.GetIdAsync(userId);
            if (userFromDB == null) { return false; }
            Mapper.Map(updatedUser, userFromDB);
            return await userRepository.UpdateEntity(userFromDB); ;
        }

        public async Task<User> CreateUser(UserDto newUser)
        {
            if (newUser == null) { return null; }
            var userEntity = Mapper.Map<User>(newUser);
            return (await userRepository.CreateEntityAsync(userEntity));
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var UserFromDB = await userRepository.FindEntityAsync(userId);
            if (UserFromDB == null) { return false; }
            return await userRepository.DeleteEntityAsync(UserFromDB); 
        }
    }
}
