using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ViewModel.Login;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Entities;
using System.Linq;
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

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
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
                string messages = "";
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        messages+= string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    }
                }
                return BadRequest(messages);
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
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Phone,
                    User = _mapper.Map<User>(model)
                };
                
                applicationUser.User.ApplicationUserId = applicationUser.Id;
                applicationUser.User.ApplicationUser = applicationUser;
              
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, "Patient");
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

        //temporary 
        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationViewModel model)
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

                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, "Admin");
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
    }
}
