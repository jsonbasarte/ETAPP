

using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Identity.Interfaces;
public interface IIdentityService
{
    Task<IActionResult> LoginUser(LoginModel loginModel);

    Task<Response> RegisterUser(RegisterUser registerModel, string role);
}

