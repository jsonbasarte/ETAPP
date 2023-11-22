using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ExpenseEntry.Commands;

public class UpdateExpenseEntryCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
    public int WalletId { get; set; }
    public TransactionType TransactionType { get; set; }
}

public class UpdateExpenseEntryCommandHandler : IRequestHandler<UpdateExpenseEntryCommand, bool>
{
    public readonly IApplicationDbContext _dbContext;

    public UpdateExpenseEntryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(UpdateExpenseEntryCommand request, CancellationToken cancellationToken)
    {
        var expense = await _dbContext.TransactionDetails.FirstAsync(e => e.Id== request.Id);

        expense.Description = request.Description;
        expense.Amount = request.Amount;
        expense.CategoryId = request.CategoryId;
        expense.WalletId = request.WalletId;
        expense.TransactionType = request.TransactionType;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
