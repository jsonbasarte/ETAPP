using Application.ExpenseEntry.Commands;
using Application.ExpenseEntry.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<int> Create(CreateExpenseEntryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IEnumerable<ExpenseDto>> GetAll()
        {
            return await Mediator.Send(new GetAllExpenseQuery()); ;
        }

        [HttpPut]
        public async Task<bool> Update(UpdateExpenseEntryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<(bool State, string Message)> Delete(DeleteExpenseEntryCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
