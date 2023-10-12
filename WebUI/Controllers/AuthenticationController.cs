using ETAPP.Application.Common.Interfaces;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public AuthenticationController(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            ICurrentUserService currentUserService
         )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

            if (userExist != null) 
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User already exists." });
            };

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };


            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User failed to create." }
                );
                   
                }
                await _userManager.AddToRoleAsync(user, role);

                return StatusCode(
                       StatusCodes.Status201Created,
                       new Response { Status = "Success", Message = "User successfully created." }
                );

            } else
            {
                return StatusCode(
                  StatusCodes.Status500InternalServerError,
                  new Response { Status = "Error", Message = "Role does not exist." }
              );
            }
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel) 
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if (user != null)
            {
                var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

                if (passwordCheck.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Success" });

                }

                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Incorrect Password." });
            } else
            {
                return StatusCode(
             StatusCodes.Status500InternalServerError,
             new Response { Status = "Error", Message = "User doesn't exist." }
         );
            }
        }


        [HttpGet]
        [Route("current-user")]
        public async Task<CurrentUserModel> GetCurrentUser()
        {
            var uid = _currentUserService.UserId!.Value;
            var user = await _userManager.Users.FirstAsync(u => u.Id == uid.ToString());

            return new CurrentUserModel
            {
                Id = uid,
                Username = user.UserName,
            };
        }
    }
}
