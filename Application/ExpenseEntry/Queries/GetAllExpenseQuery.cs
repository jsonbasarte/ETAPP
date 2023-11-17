using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using ETAPP.Application.Common.Mappings;
using MediatR;

namespace Application.ExpenseEntry.Queries;

public class ExpenseDto : IMapFrom<Expense>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
public class GetAllExpenseQuery : IRequest<IEnumerable<ExpenseDto>>{}

public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQuery, IEnumerable<ExpenseDto>>
{
    readonly IApplicationDbContext _dbContext;
    readonly IMapper _mapper;

    public GetAllExpenseQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExpenseDto>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.ExpenseEntries.ProjectToListAsync<ExpenseDto>(_mapper.ConfigurationProvider);
        return result;
    }
}