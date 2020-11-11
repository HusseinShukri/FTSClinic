using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        private readonly IUserService _userService;

        /// <summary>
        /// Get all users 
        /// </summary>
        /// <returns>an IAction result</returns>
        /// <remarks> \
        /// Sample requist(get all users) \
        /// GET Users \
        /// </remarks>
        /// <response code="200">Return the requisted Users</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null) { return NotFound(); }
            else { return Ok(new GetUsersViewModel { Users = users }); }
        }

        /// <summary>
        /// Get user by id number
        /// </summary>
        /// <param name="id">The id of the user you want to get</param>
        /// <returns>an IAction result</returns>
        /// <remarks> \
        /// Sample requist(get specific user) \
        /// GET Users/id \
        /// </remarks>
        /// <response code="200">Return the requisted User</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) { return BadRequest("User doesn't exist"); }
            else { return Ok(new GetUserViewModel { User = user }); }
        }

        /// <summary>
        /// Update user by id number
        /// </summary>
        /// <param name="user">The user object you want to update the current user to</param>
        /// <returns>an IAction result</returns>
        /// <remarks>Sample requist() \
        /// PUT Users/id \
        /// { \
        ///     "userId": 1, \
        ///     "firstName": "Hussein", \
        ///     "lastName": "Shukri", \
        ///     "login": "35555", \
        ///     "password": "h1234", \
        ///     "email": "Hussein@Shukri.com", \
        ///     "phone": "0595" \
        /// }</remarks>
        /// <response code="200">Return the updated User</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            if (!await _userService.UpdateUserAsync(user)) { return BadRequest("User doesn't exist"); }
            else { return Ok(); }
        }

        /// <summary>
        /// Create user by id number
        /// </summary>
        /// <param name="user">The user object you want to create</param>
        /// <returns>an IAction result</returns>
        /// <remarks>Sample requist() \
        /// PUT Users/id \
        /// { \
        /// "firstName": "Hassan", \
        /// "lastName": "Qadmany", \
        /// "login": "1234", \
        /// "password": "1234", \
        /// "email": "Hassan@Qadmany.com", \
        /// "phone": "1234" \
        /// }</remarks>
        /// <response code="201">Return the created User</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            var createdUser = await _userService.CreateUserAsync(user);
            if (createdUser == null) { return BadRequest("0 users crreated"); }
            else { return CreatedAtRoute("GetUser", new { id = createdUser.UserId }, createdUser); }
        }

        /// <summary>
        /// delete user by id number
        /// </summary>
        /// <param name="id">The id of the user you want to delete</param>
        /// <returns>an IAction result</returns>
        /// <remarks>Sample requist() \
        /// DELETE Users/id \
        /// </remarks>
        /// <response code="204">Return nothing</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return BadRequest("User doesn't exist"); } else { return NoContent(); }
        }
    }
}
