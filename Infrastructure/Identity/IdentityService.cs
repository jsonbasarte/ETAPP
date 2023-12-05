using ETAPP.Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public IdentityService(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<ApplicationRole> roleManager
         )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<string?> GetUserNameAsync(int userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<string> GetUserFullNameAsync(int userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return $"{user.FirstName} {user.LastName}".Trim();
        }

        public async Task<string[]> GetAllUserRoles(int userId)
        {
            var user = await _userManager.Users.FirstAsync(d => d.Id == userId);
            var allRoles = await _userManager.GetRolesAsync(user);
            return allRoles.ToArray();
        }

        public async Task<Response> RegisterUser(RegisterUser registerModel, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userExist != null)
            {
                return new Response { Status = "Error", Message = "User already exists.", StatusCode = StatusCodes.Status302Found };
            };

            ApplicationUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username,
                FirstName = "Test",
                LastName = "User"
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
            } else {
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
