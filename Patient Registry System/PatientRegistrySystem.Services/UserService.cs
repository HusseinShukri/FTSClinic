using AutoMapper;
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
            var userFromDB = await _userRepository.GetAllShallowAsync();
            if (!userFromDB.Any()) { return null; }
            return _mapper.Map<UserDto[]>(userFromDB);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var userFromDB = await _userRepository.GetIdShallowAsync(id);
            if (userFromDB == null) { return null; }
            return userFromDB;
        }

        public async Task<bool> UpdateUserAsync(UserDto updatedUser)
        {
            var userFromDB = await _userRepository.FindEntitySallowAsync(updatedUser.UserId);
            if (userFromDB == null) { return false; }
            _mapper.Map(updatedUser, userFromDB);
            return await _userRepository.UpdateEntity(updatedUser);
        }

        public async Task<UserDto> CreateUserAsync(UserDto newUser)
        {
            return _mapper.Map<UserDto>(await _userRepository.CreateEntityAsync(_mapper.Map<UserDto>(newUser)));
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var UserFromDB = await _userRepository.FindEntitySallowAsync(userId);
            if (UserFromDB == null) { return false; }
            return await _userRepository.DeleteEntityShallowAsync(UserFromDB);
        }
    }
}
