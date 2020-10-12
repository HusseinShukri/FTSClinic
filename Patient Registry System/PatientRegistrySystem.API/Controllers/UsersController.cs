using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Filters;
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
            UserService = userService;
        }
        private readonly IUserService UserService;

        [HttpGet]
        [UsersResultFilterAttribute]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await UserService.GetAllUsers();
            if (users == null) { return NotFound(); } else { return Ok(users); }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        [UserResultFilterAttribute]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await UserService.GetUser(id);
            if (user == null) { return NotFound(); } else { return Ok(user); }
        }

        [HttpPut("{id:int}")]
        [UserResultFilterAttribute]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDto user)
        {
            if (user == null) { return NotFound(); }
            if (!await UserService.UpdateUser(id, user)) { return NotFound(); }
            else { return RedirectToAction("GetUser", "Users", new { @id = id }); }
        }

        [HttpPost]
        [UserResultFilterAttribute]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var createdUser = await UserService.CreateUser(user);
            if (createdUser == null) { return NotFound(); }
            else { return CreatedAtRoute("GetUser", new { id = createdUser.UserId }, createdUser); }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await UserService.DeleteUser(id)) { return NotFound(); } else { return NoContent(); }
        }
    }
}
