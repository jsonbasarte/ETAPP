using ETAPP.Application.Common.Models;
using ETAPP.Application.Common.Models.IdentityModels;

namespace ETAPP.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(Result Result, int UserId)> CreateUserAsync(string userName, string firstName, string lastName, string password);

    Task<PaginatedList<UserListItem>> GetUsers(int page);
}