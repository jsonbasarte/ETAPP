using Application.ExpenseEntry.Commands;
using Application.ExpenseEntry.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TransactionDetailsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<int> Create(CreateExpenseEntryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<ExpenseDto>> GetAll()
        {
            return await Mediator.Send(new GetAllExpenseQuery()); ;
        }

        [HttpGet("{id}")]
        public async Task<ExpenseDetailsDto> GetById(int id)
        {
            return await Mediator.Send(new GetExpenseByIdQuery { Id = id });
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
