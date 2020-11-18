using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AdminController(UserManager<ApplicationUser> userManager,
             IMapper mapper,
            IUserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDoctor([FromBody] RegistrationDoctoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Phone,
                    User = _mapper.Map<User>(model)
                };

                applicationUser.User.ApplicationUserId = applicationUser.Id;
                applicationUser.User.ApplicationUser = applicationUser;
                applicationUser.User.Doctor.Add(new Doctor()
                {
                    Address1 = model.Adress1,
                    Address2 = model.Adress2,
                    UserId = applicationUser.User.UserId,
                    User = applicationUser.User
                });

                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, "Doctor");
                    return Ok("Created");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        var b = result.Succeeded;
                    }
                    return BadRequest(ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList());
                }
            }
            else
            {
                string messages = "";
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        messages += string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    }
                }
                return BadRequest(messages);
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _userService.GetAllDoctorssAsync();
            if (doctors == null) { return NotFound(); }
            else { return Ok(new GetUsersViewModel { Users = doctors }); }
        }


        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            if (!await _userService.UpdateUserAsync(user)) { return BadRequest("User doesn't exist"); }
            else { return Ok(); }
        }

        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return BadRequest("User doesn't exist"); } else { return NoContent(); }
        }
    }
}
