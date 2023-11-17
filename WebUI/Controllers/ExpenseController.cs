using Application.ExpenseEntry.Commands;
using Application.ExpenseEntry.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ApiControllerBase
    {
        [HttpPost]
        public async Task<int> Create(CreateExpenseEntryCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<ExpenseDto>> GetAll()
        {
            var result = await Mediator.Send(new GetAllExpenseQuery());

            return result;
        }
    }
}
