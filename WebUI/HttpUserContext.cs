using ETAPP.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ETAPP.Infrastructure;

public class HttpUserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContext;

    public HttpUserContext(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    //public string? Username => _httpContext.HttpContext?.User?.Identity?.Name;

    //public string? UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int? UserId
    {
        get
        {
            if (_httpContext.HttpContext?.User?.Identity?.IsAuthenticated != true) return null;

            try
            {
                var idValue = _httpContext.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                return (int?)Convert.ChangeType(idValue, typeof(int));
            }
            catch
            {
                // ignore all exception
                return null;
            }
        }
    }

    //public int? StoreId => throw new NotImplementedException();

    //public int? RoleId => throw new NotImplementedException();

    //int? IUserContext.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
