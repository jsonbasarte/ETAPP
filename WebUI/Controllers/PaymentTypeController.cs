using Application.PaymentMethod.Commands;
using Application.PaymentMethod.Queries;
using Application.PaymentType.Commands;
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

        [HttpPut]
        public async Task<bool> Update(UpdatePaymentTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return result;
        }

        [HttpDelete]
        public async Task<( bool State, string Message )> Delete(DeletePaymentTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return result;
        }
    }
}
