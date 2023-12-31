﻿using ETAPP.Application.Common.Interfaces;
using ETAPP.Infrastructure.Identity;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Application.Common.Models;
using ETAPP.Application.Common.Models.Login;
using ETAPP.Application.Common.Models.SignUp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebUI.Services;
using WebUI.ViewModels;

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
        public async Task<IActionResult> Register([FromBody] RegisterUserModel registerUser, string role)
        {
            var response = await _identityService.RegisterUser(registerUser, role);

            return StatusCode(response.StatusCode, new Response { Status = response.Status, Message = response.Message });
        } 


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginModel) 
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

                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Success", StatusCode = 200 });

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
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("current-user")]
        public async Task<ActionResult<ApplicationUser>> GetCurrentUser()
        {
            var uid = _currentUserService.UserId!.Value;

            var user = await _userManager.Users.FirstAsync(u => u.Id == uid);

            return Ok(new CurrentUserModel
            {
                Id = uid,
                Name = await _identityService.GetUserNameAsync(uid),
                UserName = await _identityService.GetUserFullNameAsync(uid),
                Roles = await _identityService.GetAllUserRoles(uid),
            });
        }
    }
}
