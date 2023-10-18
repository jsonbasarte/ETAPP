

using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Identity.Interfaces;
public interface IIdentityService
{
    Task<IActionResult> Login(LoginModel loginModel);

    Task<IActionResult> Register(RegisterUser registerModel, string role);
}

