using Microsoft.AspNetCore.Mvc;
using MediatR;
using ETAPP.WebUI.Filters;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiExceptionFilter]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
