using ETAPP.Application.Common.Interfaces;
using ETAPP.Infrastructure.Identity;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            ICurrentUserService currentUserService,
            IIdentityService identityService
         )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            var response = await _identityService.RegisterUser(registerUser, role);

            return StatusCode(response.StatusCode, new Response { Status = response.Status, Message = response.Message });
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

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return NoContent();
            } else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("current-user")]
        public async Task<ApplicationUser> GetCurrentUser()
        {
            var userClaims = User.Claims.ToList();
            var uid = _currentUserService.UserId!.Value;
            var user = await _userManager.Users.FirstAsync(u => u.Id == uid);
            return user;
            //return new CurrentUserModel
            //{
            //    Id = 1,
            //    Username = "Shion Jay",
            //};
        }
    }
}
