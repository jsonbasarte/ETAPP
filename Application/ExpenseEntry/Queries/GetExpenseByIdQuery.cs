

using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using ETAPP.Application.Common.Interfaces;
using ETAPP.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ExpenseEntry.Queries;

public class ExpenseDetailsDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int WalletId { get; set; }
    public string WalletName { get; set; }
    public int TransactionType { get; set; }
    public string Type { get; set; }
    public int TypeId { get; set; }
}


public class GetExpenseByIdQuery : IRequest<ExpenseDetailsDto> 
{
    public int Id { get; set; }
}

public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDetailsDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetExpenseByIdQueryHandler(IApplicationDbContext dbContext,  IMapper mapper, IUserContext userContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<ExpenseDetailsDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId!.Value;

        var transDetails = await _dbContext.TransactionDetails.FirstAsync(t => t.Id == request.Id);

        var wallet = await _dbContext.Wallet.FirstAsync(w => w.Id == transDetails.WalletId);

        var result = new ExpenseDetailsDto
        {
            Id = transDetails.Id,
            WalletName = wallet.Name,
            Amount = transDetails.Amount,
            Date = transDetails.Date,
            Description = transDetails.Description,
            Type = transDetails.TransactionType.ToString(),
            TypeId = (int)transDetails.TransactionType,
        };
        return _mapper.Map<ExpenseDetailsDto>(result);
    }
}