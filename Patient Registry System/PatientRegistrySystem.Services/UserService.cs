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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var userFromDB = await _userRepository.GetAllAsync();
            if (!userFromDB.Any()) { return null; }
            return _mapper.Map<UserDto[]>(userFromDB);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var userFromDB = await _userRepository.GetIdAsync(id);
            if (userFromDB == null) { return null; }
            return _mapper.Map<UserDto>(userFromDB);
        }

        public async Task<bool> UpdateUserAsync(int userId, UserDto updatedUser)
        {
            var userFromDB = await _userRepository.GetIdAsync(userId);
            if (userFromDB == null) { return false; }
            _mapper.Map(updatedUser, userFromDB);
            return await _userRepository.UpdateEntity(userFromDB);
        }

        public async Task<CreatedUserDto> CreateUserAsync(UserDto newUser)
        {
            if (newUser == null) { return null; }
            var userEntity = _mapper.Map<User>(newUser);
            return _mapper.Map<CreatedUserDto>((await _userRepository.CreateEntityAsync(userEntity)));
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var UserFromDB = await _userRepository.FindEntityAsync(userId);
            if (UserFromDB == null) { return false; }
            return await _userRepository.DeleteEntityAsync(UserFromDB);
        }
    }
}
