using Application.PaymentMethod.Commands;
using Application.PaymentMethod.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ApiControllerBase
    {

        [HttpPost]
        public async Task<int> Create(CreatePaymentTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentTypeDto>> GetAll()
        {
            var result = await Mediator.Send(new GetAllPaymentTypeQuery());

            return result;
        }
    }
}
