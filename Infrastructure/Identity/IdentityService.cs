using Infrastructure.Identity.Interfaces;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(
           UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
           SignInManager<IdentityUser> signInManager
         )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> RegisterUser(RegisterUser registerModel, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userExist != null)
            {
                return new Response { Status = "Error", Message = "User already exists.", StatusCode = StatusCodes.Status302Found };
            };

            IdentityUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };


            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (!result.Succeeded)
                {
                    return new Response { Status = "Error", Message = "User failed to create.", StatusCode = StatusCodes.Status500InternalServerError };

                }
                await _userManager.AddToRoleAsync(user, role);

                return new Response { Status = "Success", Message = "User successfully created.", StatusCode = StatusCodes.Status201Created };
            }

            else
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Role does not exist.",
                    StatusCode =
                  StatusCodes.Status500InternalServerError,
                };
            }
        }

    }
}
