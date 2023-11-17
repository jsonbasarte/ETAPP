using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.ExpenseEntry.Commands;

public class CreateExpenseEntryCommand: IRequest<int>
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Date {  get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int PaymentMethodId { get; set; }    
}

public class CreateExpenseEntryCommandHandler : IRequestHandler<CreateExpenseEntryCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IDateTime _dateTime;

    public CreateExpenseEntryCommandHandler(IApplicationDbContext dbContext, IDateTime dateTime)
    {
        _dbContext = dbContext;
        _dateTime = dateTime;
    }

    public async Task<int> Handle(CreateExpenseEntryCommand request, CancellationToken cancellationToken)
    {
        var expense = new Expense
        {
            Description = request.Description,
            Date = _dateTime.Now,
            Amount = request.Amount,
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            PaymentMethodId = request.PaymentMethodId,
        };

        _dbContext.ExpenseEntries.Add(expense);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return expense.Id;
    }
}