using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ControllersHelper;
using PatientRegistrySystem.API.ViewModel.Login;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services.AdminServices;
using PatientRegistrySystem.Services.PatientServices;
using System.Threading.Tasks;

namespace PatientRegistrySystem.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAdminService _adminServices;
        private readonly IPatientService _pationtService;

        public AccountController(UserManager<ApplicationUser> userManager
             ,SignInManager<ApplicationUser> signInManager
            , IMapper mapper,
            IAdminService adminServices,
            IPatientService pationtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _adminServices = adminServices;
            _pationtService = pationtService;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _userManager.FindByEmailAsync(model.Email)) != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Fild to signin ");
                    }
                }
                else
                {
                    return BadRequest("Invaled Email or passowrd");
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _pationtService.CreatePatientAsync(_mapper.Map<ApplicationUserDto>(model), model.Password);
                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest(result.GetErrors());
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        //temporary 
        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminServices.CreateAdminAsync(_mapper.Map<ApplicationUserDto>(model), model.Password);
                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest(result.GetErrors());
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }
    }
}
