﻿using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using ETAPP.Application.Common.Interfaces;
using ETAPP.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ExpenseEntry.Queries;

public class ExpenseDto : IMapFrom<TransactionDetails>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int WalletId { get; set; }
    public string WalletName { get; set; }
    public int TransactionType { get; set; }
    public string Type { get; set; }
}
public class GetAllExpenseQuery : IRequest<IEnumerable<ExpenseDto>>{}

public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQuery, IEnumerable<ExpenseDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllExpenseQueryHandler(IApplicationDbContext dbContext, IMapper mapper, IUserContext userContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IEnumerable<ExpenseDto>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId!.Value;

        var result = await _dbContext.TransactionDetails.Where(trans => trans.UserId == userId)
            .ProjectToListAsync<ExpenseDto>(_mapper.ConfigurationProvider);

        var list = new List<ExpenseDto>();
        
        foreach (var item in result)
        {
            var wallet = await _dbContext.Wallet.FirstAsync(w => w.Id == item.WalletId);
            var type = (TransactionType)item.TransactionType;
            list.Add(
                new ExpenseDto { Id = item.Id, WalletName = wallet.Name,  Amount = item.Amount, Date = item.Date, Description = item.Description, Type = type.ToString()});
        }

        return list;
    }
}