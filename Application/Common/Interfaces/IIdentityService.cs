

using Application.Common.Models;
using ETAPP.Application.Common.Models.SignUp;

namespace Infrastructure.Identity.Interfaces;
public interface IIdentityService
{
    Task<Response> RegisterUser(RegisterUserModel registerModel, string role);

    Task<string> GetUserNameAsync(int userId);

    Task<string> GetUserFullNameAsync(int userId);

    Task<string[]> GetAllUserRoles(int userId);

    Task<bool> IsInRoleAsync(int userId, string role);

    Task<bool> AuthorizeAsync(int userId, string policyName);
}

