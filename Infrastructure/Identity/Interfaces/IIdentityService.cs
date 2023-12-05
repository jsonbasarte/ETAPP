

using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Login;
using Infrastructure.Identity.Models.SignUp;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Identity.Interfaces;
public interface IIdentityService
{
    Task<Response> RegisterUser(RegisterUser registerModel, string role);

    Task<string> GetUserNameAsync(int userId);

    Task<string> GetUserFullNameAsync(int userId);

    Task<string[]> GetAllUserRoles(int userId);
}

