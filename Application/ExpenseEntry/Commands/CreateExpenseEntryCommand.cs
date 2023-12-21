using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ExpenseEntry.Commands;

public class CreateExpenseEntryCommand: IRequest<int>
{
    public string Description { get; set; }
    public decimal Amount { get; set; }  
    public DateTime? Date {  get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int WalletId { get; set; }
    public TransactionType TransactionType { get; set; }
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
        //IQueryable<Wallet> q = _dbContext.Wallet;

        //q = q.Where(w => w.UserId == request.UserId);

        //q = q.Where(w => w.Id == request.WalletId);

     var userWallet = await _dbContext.Wallet.FirstAsync(w => w.UserId == request.UserId && w.Id == request.WalletId);

     var expense = new TransactionDetails
        {
            Description = request.Description,
            Date = _dateTime.Now,
            Amount = request.Amount,
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            WalletId = request.WalletId,
            TransactionType = request.TransactionType,
        };

        if (request.TransactionType == TransactionType.Expense)
        {

            userWallet.Balance = userWallet.Balance - request.Amount;

        }
        else if (request.TransactionType == TransactionType.Credit)
        {
            userWallet.Balance = userWallet.Balance + request.Amount;
        }

        _dbContext.TransactionDetails.Add(expense);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return expense.Id;
    }
}

public class CreateExpenseEntryCommandValidator : AbstractValidator<CreateExpenseEntryCommand>
{
    public CreateExpenseEntryCommandValidator() 
    {
        RuleFor(d => d.Description).NotEmpty().WithMessage("Description is required.");    
    }
}