using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExpenseEntry.Commands;

public class DeleteExpenseEntryCommand : IRequest<(bool State, string Message)>
{
   public int Id { get; set; }
}

public class DeleteExpenseEntryCommandHandler : IRequestHandler<DeleteExpenseEntryCommand, (bool State, string Message)>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteExpenseEntryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool State, string Message)> Handle(DeleteExpenseEntryCommand request, CancellationToken cancellationToken)
    {
        var expense = await _dbContext.ExpenseEntries.FirstAsync(e => e.Id == request.Id);

         _dbContext.ExpenseEntries.Remove(expense);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return (true, "OK");
    }
}
